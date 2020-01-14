namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Utilities.App;
    using Pharus.Services.Files;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.Services.ShareClasses.Contracts;
    using Pharus.App.Models.BindingModels.ShareClasses;
    using System.IO;

    [Authorize]
    public class ShareClassesController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly IShareClassesService shareClassesService;
        private readonly IShareClassesSelectListService shareClassesSelectListService;
        private readonly IEntitiesFileService entitiesFileService;
        private readonly IHostingEnvironment hostingEnvironment;

        public ShareClassesController(
            IShareClassesService shareClassesService,
            IShareClassesSelectListService shareClassesSelectListService,
            Pharus_vFinale_Context context,
            IEntitiesFileService entitiesFileService,
            IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
            this.shareClassesService = shareClassesService;
            this.shareClassesSelectListService = shareClassesSelectListService;
            this.entitiesFileService = entitiesFileService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
                EntitiesHeadersForColumnSelection = this.shareClassesService.GetAllActiveShareClasses().Take(1).ToList(),
                Entities = this.shareClassesService.GetAllActiveShareClasses(),
            };

            this.ModelState.Clear();
            return this.View(model);
        }

        public JsonResult AutoCompleteShareClassesList(string selectTerm)
        {
            var result = this.context
                .TbHistoryShareClass
                .GroupBy(hsc => hsc.ScOfficialShareClassName)
                .Select(hsc => hsc.FirstOrDefault())
                .ToList();

            if (selectTerm != null)
            {
                result = this.context
                    .TbHistoryShareClass
                    .Where(hsc => hsc.ScOfficialShareClassName.Contains(selectTerm))
                    .GroupBy(hsc => hsc.ScOfficialShareClassName)
                    .Select(hsc => hsc.FirstOrDefault())
                    .ToList();
            }

            var modifiedData = result.Select(hsc => new
            {
                id = hsc.ScOfficialShareClassName,
                text = hsc.ScOfficialShareClassName,
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.EntitiesHeadersForColumnSelection = this.shareClassesService.GetAllActiveShareClasses().Take(1).ToList();

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            DateTime? chosenDate = null;

            if (model.ChosenDate != null)
            {
                chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            if (isInSelectionMode)
            {
                if (model.IsActive)
                {
                    CallActiveEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!model.IsActive)
                {
                    CallAllEntitiesWithSelectedColumns(model, chosenDate);
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Entities = this.shareClassesService.GetAllActiveShareClasses(chosenDate);
                }
                else if (!model.IsActive)
                {
                    model.Entities = this.shareClassesService.GetAllShareClasses(chosenDate);
                }
            }

            if (model.SelectTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities, model.SelectTerm.ToLower());
            }

            if (model.SearchTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities, model.SearchTerm.ToLower());
            }

            if (model.Entities != null)
            {
                return this.View(model);
            }

            return this.RedirectToPage("/ShareClasses/All");
        }

        [HttpPost]
        public FileStreamResult ExtractExcelEntities(EntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.Entities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfEntities(EntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (model.Entities[0].Length > 16)
            {
                model.Entities = this.shareClassesService.PrepareShareClassesForPDFExtract(chosenDate);
            }

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.Entities, chosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("ShareClasses/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(int entityId, string chosenDate)
        {
            var date = DateTime.Parse(chosenDate);

            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            SetModelValuesForSpecificView(viewModel);

            HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

            string fileName = GetFileNameFromFilePath(entityId, chosenDate);

            if (string.IsNullOrEmpty(fileName))
            {
                return this.View(viewModel);
            }

            viewModel.FileNameToDisplay = fileName;

            this.ModelState.Clear();
            return this.View(viewModel);
        }

        [HttpPost("ShareClasses/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            model.Entity = this.shareClassesService
                 .GetShareClassWithDateById(chosenDate, model.EntityId);

            if (model.Entity != null)
            {
                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult UploadProspectus(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            var file = model.UploadEntityFileModel.FileToUpload;

            if (!ModelState.IsValid || file == null || file.Length == 0)
            {
                return this.Content("File not loaded");
            }

            string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\ShareclassFile\";
            string path = $"{networkFileLocation}{file.FileName}";

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var startConnection = DateTime.ParseExact(model.StartConnection, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime? endConnection = null;

            if (!string.IsNullOrEmpty(model.EndConnection))
            {
                endConnection = DateTime.ParseExact(model.EndConnection, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            var fileTypeDesc = model.UploadEntityFileModel.FileType;
            int fileTypeId = this.context.TbDomFileType
                    .Where(s => s.FiletypeDesc == fileTypeDesc)
                    .Select(s => s.FiletypeId)
                    .FirstOrDefault();

            this.entitiesFileService.AddFileToSpecificShareClass(
                                                file.FileName,
                                                model.EntityId,
                                                startConnection,
                                                endConnection,
                                                fileTypeId);

            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult UploadAgreement(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            var file = model.UploadEntityFileModel.FileToUpload;

            if (!ModelState.IsValid || file == null || file.Length == 0)
            {
                return this.Content("File not loaded");
            }

            string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\ShareclassFile\";
            string path = $"{networkFileLocation}{file.FileName}";

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var startConnection = DateTime.ParseExact(model.StartConnection, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime? endConnection = null;

            if (!string.IsNullOrEmpty(model.EndConnection))
            {
                endConnection = DateTime.ParseExact(model.EndConnection, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            var fileTypeDesc = model.UploadEntityFileModel.FileType;
            int fileTypeId = this.context.TbDomFileType
                    .Where(s => s.FiletypeDesc == fileTypeDesc)
                    .Select(s => s.FiletypeId)
                    .FirstOrDefault();

            this.entitiesFileService.AddFileToSpecificShareClass(
                                                file.FileName,
                                                model.EntityId,
                                                startConnection,
                                                endConnection,
                                                fileTypeId);

            return this.RedirectToAction("All");
        }

        [HttpPost]
        public FileStream ReadPdfFile(SpecificEntityViewModel model)
        {
            FileStream fs = null;

            var path = this.entitiesFileService.LoadShareClassFileToDisplay(model.EntityId, model.ChosenDate);

            if (this.HttpContext.Request.Form.ContainsKey("read_Pdf"))
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            }

            return fs;
        }

        [HttpGet("ShareClasses/EditShareClass/{EntityId}/{ChosenDate}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditShareClass(int entityId, string chosenDate)
        {
            var date = DateTime.Parse(chosenDate);

            EditShareClassBindingModel model = new EditShareClassBindingModel
            {
                EntityProperties = this.shareClassesService.GetShareClassWithDateById(date, entityId),
                InitialDate = DateTime.Today,
                ShareClassId = entityId,
            };

            SetModelValuesForEditView(model);

            SetViewDataValuesForShareClassesSelectLists();

            return this.View(model);
        }

        [HttpPost("ShareClasses/EditShareClass/{EntityId}/{ChosenDate}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditShareClass(EditShareClassBindingModel model, int entityId, string chosenDate)
        {
            string returnUrl = $"/ShareClasses/All/";

            if (!ModelState.IsValid)
            {
                if (model.EntityProperties == null)
                {
                    var date = DateTime.Parse(chosenDate);
                    model.EntityProperties = this.shareClassesService.GetShareClassWithDateById(date, entityId);
                    SetModelValuesForEditView(model);
                    SetViewDataValuesForShareClassesSelectLists();
                }
                return View(model ?? new EditShareClassBindingModel());
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateShareClass()
        {
            CreateShareClassBindingModel model = new CreateShareClassBindingModel
            {
                InitialDate = DateTime.Today,
            };

            SetViewDataValuesForShareClassesSelectLists();

            this.ModelState.Clear();
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]

        public IActionResult CreateShareClass(CreateShareClassBindingModel model)
        {
            string returnUrl = "/ShareClasses/All";

            SetViewDataValuesForShareClassesSelectLists();

            model.ExistingEntitiesNames = this.shareClassesService.GetAllShareClassesNames();

            if (!this.ModelState.IsValid || model.ExistingEntitiesNames.Any(sf => sf == model.ShareClassName))
            {
                return this.View(model ?? new CreateShareClassBindingModel());
            }

            string initialDate = model.InitialDate.ToString("yyyyMMdd");
            string endDate = model.EndDate?.ToString("yyyyMMdd");
            string emissionDate = model.EmissionDate?.ToString("yyyyMMdd");
            string inceptionDate = model.InceptionDate?.ToString("yyyyMMdd");
            string lastNavDate = model.LastNavDate?.ToString("yyyyMMdd");
            string expiryDate = model.ExpiryDate?.ToString("yyyyMMdd");
            string businessYearDate = model.DateBusinessYear?.ToString("yyyyMMdd");

            List<int?> nullIntegerParameters = new List<int?>();

            if (this.HttpContext.Request.Form.ContainsKey("create_button"))
            {
                string shareClassName = model.ShareClassName;

                int? investorTypeId = this.context.TbDomInvestorType
                    .Where(it => it.ItDesc == model.InvestorType)
                    .Select(it => it.ItId)
                    .FirstOrDefault();

                int? shareTypeId = this.context.TbDomInvestorType
                  .Where(it => it.ItDesc == model.InvestorType)
                  .Select(it => it.ItId)
                  .FirstOrDefault();

                string currency = this.context.TbDomIsoCurrency
                   .Where(c => c.IsoCcyDesc == model.CurrencyCode)
                   .Select(c => c.IsoCcyCode)
                   .FirstOrDefault();

                // Split to take only companyTypeDesc for comparing

                string countryIssue = null;

                if (!string.IsNullOrEmpty(model.CountryIssue))
                {
                    string countryIssueDesc = model.CountryIssue.Split(" - ").LastOrDefault();
                    countryIssue = this.context.TbDomIsoCountry
                        .Where(c => c.IsoCountryDesc == countryIssueDesc)
                        .Select(c => c.IsoCountry3)
                        .FirstOrDefault();
                }

                string countryRisk = null;

                if (!string.IsNullOrEmpty(model.CountryRisk))
                {
                    string countryRiskDesc = model.CountryRisk.Split(" - ").LastOrDefault();
                    countryRisk = this.context.TbDomIsoCountry
                    .Where(c => c.IsoCountryDesc == countryRiskDesc)
                    .Select(c => c.IsoCountry3)
                    .FirstOrDefault();
                }

                int scStatusId = this.context.TbDomShareStatus
                    .Where(s => s.ScSDesc == model.Status)
                    .Select(s => s.ScSId)
                    .FirstOrDefault();

                double initialPrice = model.InitialPrice;
                string accountingCode = model.AccountingCode;

                bool isHedged = false;

                if (model.IsHedged == "Yes")
                {
                    isHedged = true;
                }

                bool isListed = false;

                if (model.IsListed == "Yes")
                {
                    isListed = true;
                }

                string bloombergMarket = model.BloombergMarket;
                string bloombergCode = model.BloombergCode;
                string bloombergId = model.BloombergId;
                string isinCode = model.ISINCode;
                string valorCode = model.ValorCode;
                string faCode = model.FACode;
                string taCode = model.TACode;
                string WKN = model.WKN;
                string prospectusCode = model.ProspectusCode;

                int subFundContainerId = this.context.TbHistorySubFund
                   .Where(sfc => sfc.SfOfficialSubFundName == model.SubFundContainer)
                   .Select(sfc => sfc.SfId)
                   .FirstOrDefault();

                SetZeroValuesToNull(nullIntegerParameters, investorTypeId, shareTypeId);

                this.shareClassesService.CreateShareClass(
                                                initialDate, endDate, shareClassName, nullIntegerParameters[0],
                                                nullIntegerParameters[1], currency, countryIssue, countryRisk,
                                                emissionDate, inceptionDate, lastNavDate, expiryDate,
                                                scStatusId, initialPrice, accountingCode, isHedged, isListed,
                                                bloombergMarket, bloombergCode, bloombergId, isinCode,
                                                valorCode, faCode, taCode, WKN, businessYearDate,
                                                prospectusCode, subFundContainerId);
            }
            // End of if statement

            return this.LocalRedirect(returnUrl);
        }

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            var date = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.Entity = this.shareClassesService.GetShareClassWithDateById(date, entityId);
            model.EntityTimeline = this.shareClassesService.GetShareClassesTimeline(entityId);
            model.EntityDocuments = this.shareClassesService.GetAllShareClassesDocumens(entityId);
            model.BaseEntityName = this.shareClassesService.GetShareClass_SubFundContainer(date, entityId)[1][1];
            model.BaseEntityId = this.shareClassesService.GetShareClass_SubFundContainer(date, entityId)[1][0];
            model.TSPriceDates = this.shareClassesService
                        .GetShareClassTimeSeriesDates(entityId)
                        .Skip(1)
                        .Select(ts => ts[1])
                        .ToList();
            model.TSTableType = this.shareClassesService
                        .GetTimeseriesTypeProviders(entityId)
                        .Skip(1)
                        .Select(tt => tt[0])
                        .ToList();
            model.TSPriceBloombergEUR = this.shareClassesService
                        .GetShareClassTimeSeries(entityId)
                        .Skip(1)
                        .Where(ts => ts[2] == "Bloomberg EUR")
                        .Select(ts => ts[1])
                        .ToList();
            model.TSPriceBloombergUSD = this.shareClassesService
                        .GetShareClassTimeSeries(entityId)
                        .Skip(1)
                        .Where(ts => ts[2] == "Bloomberg USD")
                        .Select(ts => ts[1])
                        .ToList();
            model.TSPriceSixUSD = this.shareClassesService
                        .GetShareClassTimeSeries(entityId)
                        .Skip(1)
                        .Where(ts => ts[2] == "SiX EUR")
                        .Select(ts => ts[1])
                        .ToList();

            model.StartConnection = model.Entity[1][0];
            model.EndConnection = model.Entity[1][1];

            this.ViewData["FileTypes"] = this.shareClassesSelectListService.GetAllShareClassFileTypes();
        }
        private void SetModelValuesForEditView(EditShareClassBindingModel model)
        {
            model.ShareClassName = model.EntityProperties[1][3];
        }

        private void SetViewDataValuesForShareClassesSelectLists()
        {
            this.ViewData["Status"] = this.shareClassesSelectListService.GetAllTbDomShareStatus();
            this.ViewData["InvestorType"] = this.shareClassesSelectListService.GetAllTbDomInvestorType();
            this.ViewData["ShareType"] = this.shareClassesSelectListService.GetAllTbDomShareType();
            this.ViewData["CurrencyCode"] = this.shareClassesSelectListService.GetAllTbDomCurrencyCode();
            this.ViewData["Country"] = this.shareClassesSelectListService.GetAllTbDomCountry();

            this.ViewData["SubFundContainer"] = this.context.TbHistorySubFund.Select(sf => sf.SfOfficialSubFundName).ToList();
        }

        private static void SetZeroValuesToNull(
                                            List<int?> nullIntegerParameters, int? investorTypeId, int? shareTypeId)
        {
            nullIntegerParameters.Add(investorTypeId);
            nullIntegerParameters.Add(shareTypeId);

            for (int i = 0; i < nullIntegerParameters.Count; i++)
            {
                if (nullIntegerParameters[i] == 0)
                {
                    nullIntegerParameters[i] = null;
                }
            }
        }

        private void CallAllEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.shareClassesService.GetAllShareClassesWithSelectedViewAndDate(
                model.PreSelectedColumns,
                model.SelectedColumns,
                chosenDate);
        }

        private void CallActiveEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.shareClassesService.GetAllActiveShareClassesWithSelectedViewAndDate(
                                        model.PreSelectedColumns,
                                        model.SelectedColumns,
                                        chosenDate);
        }

        private string GetFileNameFromFilePath(int entityId, string chosenDate)
        {
            return this.entitiesFileService.LoadShareClassFileToDisplay(entityId, chosenDate).Split('\\').Last();
        }
    }
}