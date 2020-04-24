namespace DataGate.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;

    using DataGate.Data;
    using DataGate.Web.Utilities;
    using DataGate.Utilities.Web;
    using DataGate.Services.Files;
    using DataGate.Services.ShareClasses.Contracts;
    using DataGate.Web.InputModels.ShareClasses;
    using DataGate.Services.Agreements.Contracts;
    using DataGate.Web.ViewModels.Entities;

    [Authorize]
    public class ShareClassesController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly IShareClassesService shareClassesService;
        private readonly IShareClassesSelectListService shareClassesSelectListService;
        private readonly IAgreementsSelectListService agreementsSelectListService;
        private readonly IEntitiesFileService entitiesFileService;
        private readonly IWebHostEnvironment _environment;

        public ShareClassesController(
            IShareClassesService shareClassesService,
            IShareClassesSelectListService shareClassesSelectListService,
            IAgreementsSelectListService agreementsSelectListService,
            Pharus_vFinale_Context context,
            IEntitiesFileService entitiesFileService,
            IWebHostEnvironment hostingEnvironment)
        {
            this.context = context;
            this._environment = hostingEnvironment;
            this.shareClassesService = shareClassesService;
            this.shareClassesSelectListService = shareClassesSelectListService;
            this.agreementsSelectListService = agreementsSelectListService;
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

            //if (!string.IsNullOrEmpty(command))
            //{
            //    FileStreamResult fileStreamResult = null;
            //    string typeName = model.GetType().Name;
            //    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            //    if (command == "ExtractExcel")
            //    {
            //        fileStreamResult = ExtractTable.ExtractTableAsExcel(model.Entities, typeName, controllerName);
            //    }

            //    else if (command == "ExtractPDF")
            //    {
            //        fileStreamResult = ExtractTable
            //            .ExtractTableAsPdf(model.Entities, chosenDate, this._environment, typeName, controllerName);
            //    }
            //    return fileStreamResult;
            //}

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
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.Entities, chosenDate, this._environment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("ShareClasses/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            SetModelValuesForSpecificView(viewModel);

            HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

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
        public IActionResult UploadDocument(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            var file = model.UploadEntityFileModel.FileToUpload;

            if (file != null || file.FileName != "")
            {
                string fileExt = Path.GetExtension(file.FileName);
                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\ShareClasses\");
                string path = $"{fileLocation}{file.FileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();
                }

                string startConnection = model.StartConnection.ToString("yyyyMMdd");
                string endConnection = model.EndConnection?.ToString("yyyyMMdd");

                var fileTypeDesc = model.UploadEntityFileModel.DocumentType;
                int fileTypeId = this.context.TbDomFileType
                        .Where(s => s.FiletypeDesc == fileTypeDesc)
                        .Select(s => s.FiletypeId)
                        .FirstOrDefault();

                this.entitiesFileService.AddDocumentToSpecificEntity(
                                                    file.FileName,
                                                    model.EntityId,
                                                    startConnection,
                                                    endConnection,
                                                    fileExt,
                                                    fileTypeId,
                                                    model.ControllerName);

            }

            return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        }

        [HttpPost]
        public IActionResult UploadAgreement(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            //if (!ModelState.IsValid)
            //{
            //    return this.PartialView("SpecificEntity/_UploadAgr", model);
            //}

            var file = model.UploadAgreementFileModel.FileToUpload;

            if (file != null || file.FileName != "")
            {
                string fileExt = Path.GetExtension(file.FileName);
                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
                string path = $"{fileLocation}{file.FileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();
                }

                var activityTypeIdDesc = model.UploadAgreementFileModel.AgrType;
                int activityTypeId = this.context.TbDomActivityType
                        .Where(at => at.AtDesc == activityTypeIdDesc)
                        .Select(at => at.AtId)
                        .FirstOrDefault();

                string contractDate = model.UploadAgreementFileModel.ContractDate.ToString("yyyyMMdd");
                string activationDate = model.UploadAgreementFileModel.ActivationDate.ToString("yyyyMMdd");
                string expirationDate = model.UploadAgreementFileModel.ExpirationDate?.ToString("yyyyMMdd");

                int statusId = this.context.TbDomAgreementStatus
                    .Where(s => s.ASDesc == model.UploadAgreementFileModel.Status)
                    .Select(s => s.ASId)
                    .FirstOrDefault();

                int companyId = this.context.TbCompanies
                    .Where(c => c.CName == model.UploadAgreementFileModel.Company)
                    .Select(c => c.CId)
                    .FirstOrDefault();

                this.entitiesFileService.AddAgreementToSpecificEntity(
                                                    file.FileName,
                                                    fileExt,
                                                    model.EntityId,
                                                    activityTypeId,
                                                    contractDate,
                                                    activationDate,
                                                    expirationDate,
                                                    statusId,
                                                    companyId,
                                                    model.ControllerName);
            }

            this.ModelState.Clear();
            return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        }

        [HttpPost]
        public IActionResult ReadDocument(string pdfValue)
        {
            FileStreamResult fileStreamResult = null;

            string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\ShareClasses\");
            string path = $"{fileLocation}{pdfValue}";

            if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }

            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult ReadAgreement(string pdfValue)
        {
            FileStreamResult fileStreamResult = null;

            string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
            string path = $"{fileLocation}{pdfValue}";

            if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
            }

            if (fileStreamResult != null)
            {
                return fileStreamResult;
            }

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public JsonResult DeleteDocument(string docName)
        {
            if (!string.IsNullOrEmpty(docName))
            {
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                this.entitiesFileService.DeleteDocumentMapping(docName, controllerName);

                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\ShareClasses\");
                string path = $"{fileLocation}{docName}";

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return Json(new { data = Path.GetFileNameWithoutExtension(docName) });
                }
            }

            return Json(new { data = "false" });
        }

        [HttpGet]
        public JsonResult DeleteAgreement(string agrName)
        {
            if (!string.IsNullOrEmpty(agrName))
            {
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                this.entitiesFileService.DeleteAgreementMapping(agrName, controllerName);

                string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
                string path = $"{fileLocation}{agrName}";

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return Json(new { data = Path.GetFileNameWithoutExtension(agrName) });
                }
            }

            return Json(new { data = "false" });
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
        [ValidateAntiForgeryToken]
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

            if (this.HttpContext.Request.Form.ContainsKey("update_button"))
            {
                List<int?> nullIntegerParameters = new List<int?>();

                int scId = model.ShareClassId;
                string initialDate = model.InitialDate.ToString("yyyyMMdd");
                string endDate = model.EndDate?.ToString("yyyyMMdd");
                string shareClassName = model.ShareClassName;

                int? investorTypeId = this.context.TbDomInvestorType
                    .Where(it => it.ItDesc == model.InvestorType)
                    .Select(it => it.ItId)
                    .FirstOrDefault();

                int? shareTypeId = this.context.TbDomInvestorType
                  .Where(it => it.ItDesc == model.InvestorType)
                  .Select(it => it.ItId)
                  .FirstOrDefault();

                string currency = model.CurrencyCode;

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

                string emissionDate = model.EmissionDate?.ToString("yyyyMMdd");
                string inceptionDate = model.InceptionDate?.ToString("yyyyMMdd");
                string lastNavDate = model.LastNavDate?.ToString("yyyyMMdd");
                string expiryDate = model.ExpiryDate?.ToString("yyyyMMdd");

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
                string businessYearDate = model.DateBusinessYear?.ToString("yyyyMMdd");
                string prospectusCode = model.ProspectusCode;

                string comment = model.CommentArea;
                string commentTitle = model.CommentTitle;

                SetZeroValuesToNull(nullIntegerParameters, investorTypeId, shareTypeId);

                this.shareClassesService.EditShareClass(
                                                scId, initialDate, shareClassName, nullIntegerParameters[0],
                                                nullIntegerParameters[1], currency, countryIssue, countryRisk,
                                                emissionDate, inceptionDate, lastNavDate, expiryDate,
                                                scStatusId, initialPrice, accountingCode, isHedged, isListed,
                                                bloombergMarket, bloombergCode, bloombergId, isinCode,
                                                valorCode, faCode, taCode, WKN, businessYearDate,
                                                prospectusCode, comment, commentTitle);
            }
            // End of if statement

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

            if (this.HttpContext.Request.Form.ContainsKey("create_button"))
            {
                List<int?> nullIntegerParameters = new List<int?>();

                string initialDate = model.InitialDate.ToString("yyyyMMdd");
                string endDate = model.EndDate?.ToString("yyyyMMdd");
                string shareClassName = model.ShareClassName;

                int? investorTypeId = this.context.TbDomInvestorType
                    .Where(it => it.ItDesc == model.InvestorType)
                    .Select(it => it.ItId)
                    .FirstOrDefault();

                int? shareTypeId = this.context.TbDomInvestorType
                  .Where(it => it.ItDesc == model.InvestorType)
                  .Select(it => it.ItId)
                  .FirstOrDefault();

                string currency = model.CurrencyCode;

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

                string emissionDate = model.EmissionDate?.ToString("yyyyMMdd");
                string inceptionDate = model.InceptionDate?.ToString("yyyyMMdd");
                string lastNavDate = model.LastNavDate?.ToString("yyyyMMdd");
                string expiryDate = model.ExpiryDate?.ToString("yyyyMMdd");

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
                string businessYearDate = model.DateBusinessYear?.ToString("yyyyMMdd");
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
            model.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            model.Entity = this.shareClassesService.GetShareClassWithDateById(date, entityId);
            model.ContainerEntityName = this.shareClassesService.GetShareClass_SubFundContainer(date, entityId)[1][1];
            model.ContainerEntityId = this.shareClassesService.GetShareClass_SubFundContainer(date, entityId)[1][0];
            model.TSPriceDates = this.shareClassesService
                        .GetShareClassTimeSeriesDates(entityId)
                        .Skip(1)
                        .Select(ts => ts[1])
                        .ToList();
            model.TSTypeProviders = this.shareClassesService
                        .GetTimeseriesTypeProviders(entityId)
                        .Skip(1)
                        .Select(tt => tt[0])
                        .ToList();

            model.TSAllPriceValues = this.shareClassesService
                       .GetShareClassTimeSeriesData(entityId)
                       .Skip(1)
                       .ToList();
            model.EntityDistinctDocuments = this.shareClassesService.GetDistinctShareClassDocuments(date, entityId);
            model.EntityDistinctAgreements = this.shareClassesService.GetDistinctShareClassAgreements(date, entityId);

            model.EntityDocuments = this.shareClassesService.GetAllShareClassDocuments(entityId);
            model.EntityAgreements = this.shareClassesService.GetAllShareClassAgreements(date, entityId);
            model.EntityTimeline = this.shareClassesService.GetShareClassesTimeline(entityId);

            model.StartConnection = DateTime.ParseExact(model.Entity[1][0], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (model.EndConnection != null)
            {
                model.EndConnection = DateTime.ParseExact(model.Entity[1][1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            this.ViewData["FileTypes"] = this.shareClassesSelectListService.GetAllShareClassFileTypes();
            this.ViewData["AgreementsFileTypes"] = this.shareClassesSelectListService.GetAllAgreementsFileTypes();
            this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }
        private void SetModelValuesForEditView(EditShareClassBindingModel model)
        {
            model.ShareClassName = model.EntityProperties[1][3];

            if (!string.IsNullOrEmpty(model.EntityProperties[1][10]))
            {
                model.EmissionDate = DateTime.ParseExact(model.EntityProperties[1][10], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(model.EntityProperties[1][11]))
            {
                model.InceptionDate = DateTime.ParseExact(model.EntityProperties[1][11], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(model.EntityProperties[1][12]))
            {
                model.LastNavDate = DateTime.ParseExact(model.EntityProperties[1][12], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(model.EntityProperties[1][13]))
            {
                model.ExpiryDate = DateTime.ParseExact(model.EntityProperties[1][13], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            model.InitialPrice = double.Parse(model.EntityProperties[1][15]);
            model.AccountingCode = model.EntityProperties[1][16];
            model.IsHedged = model.EntityProperties[1][17];
            model.IsListed = model.EntityProperties[1][18];
            model.BloombergMarket = model.EntityProperties[1][19];
            model.BloombergCode = model.EntityProperties[1][20];
            model.BloombergId = model.EntityProperties[1][21];
            model.ISINCode = model.EntityProperties[1][22];
            model.ValorCode = model.EntityProperties[1][23];
            model.FACode = model.EntityProperties[1][24];
            model.TACode = model.EntityProperties[1][25];
            model.WKN = model.EntityProperties[1][26];

            if (!string.IsNullOrEmpty(model.EntityProperties[1][27]))
            {
                model.DateBusinessYear = DateTime.ParseExact(model.EntityProperties[1][27], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            model.ProspectusCode = model.EntityProperties[1][28];
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
    }
}