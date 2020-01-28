namespace Pharus.App.Controllers
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

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Utilities.App;
    using Pharus.Services.Files;
    using Pharus.Services.SubFunds.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.SubFunds;
    using Pharus.Services.Agreements.Contracts;

    [Authorize]
    public class SubFundsController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly ISubFundsService subFundsService;
        private readonly ISubFundsSelectListService subfundsSelectListService;
        private readonly IAgreementsSelectListService agreementsSelectListService;
        private readonly IEntitiesFileService entitiesFileService;
        private readonly IHostingEnvironment hostingEnvironment;

        public SubFundsController(
            Pharus_vFinale_Context context,
            ISubFundsService subFundsService,
            ISubFundsSelectListService subfundsSelectListService,
            IAgreementsSelectListService agreementsSelectListService,
            IEntitiesFileService entitiesFileService,
            IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.subFundsService = subFundsService;
            this.subfundsSelectListService = subfundsSelectListService;
            this.agreementsSelectListService = agreementsSelectListService;
            this.entitiesFileService = entitiesFileService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
                EntitiesHeadersForColumnSelection = this.subFundsService.GetAllActiveSubFunds().Take(1).ToList(),
                Entities = this.subFundsService.GetAllActiveSubFunds(),
            };

            this.ModelState.Clear();
            return this.View(model);
        }

        public JsonResult AutoCompleteSubFundList(string selectTerm)
        {
            var result = this.context
                .TbHistorySubFund
                .GroupBy(hsf => hsf.SfOfficialSubFundName)
                .Select(hsf => hsf.FirstOrDefault())
                .ToList();

            if (selectTerm != null)
            {
                result = this.context
                    .TbHistorySubFund
                    .Where(hsf => hsf.SfOfficialSubFundName.Contains(selectTerm))
                    .GroupBy(hsf => hsf.SfOfficialSubFundName)
                    .Select(hsf => hsf.FirstOrDefault())
                    .ToList();
            }

            var modifiedData = result.Select(hsf => new
            {
                id = hsf.SfOfficialSubFundName,
                text = hsf.SfOfficialSubFundName,
            });
            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.EntitiesHeadersForColumnSelection = this.subFundsService.GetAllActiveSubFunds().Take(1).ToList();

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
                    model.Entities = this.subFundsService.GetAllActiveSubFunds(chosenDate);
                }
                else if (!model.IsActive)
                {
                    model.Entities = this.subFundsService.GetAllSubFunds(chosenDate);
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

            return this.RedirectToPage("/SubFunds/All");
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
            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (model.Entities[0].Length > 16)
            {
                model.Entities = this.subFundsService.PrepareSubFundsForPDFExtract(chosenDate);
            }

            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.Entities, chosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("SubFunds/ViewEntitySE/{EntityId}/{ChosenDate}")]
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

        public JsonResult AutoCompleteShareClassesList(string selectTerm, int entityId)
        {
            var entitiesToSearch = this.subFundsService
                .GetSubFund_ShareClasses(null, entityId)
                .Skip(1)
                .ToList();

            if (selectTerm != null)
            {
                entitiesToSearch = entitiesToSearch.Where(sc => sc[3]
                                                        .ToLower()
                                                        .Contains(selectTerm
                                                        .ToLower()))
                                                    .ToList();
            }

            var modifiedData = entitiesToSearch.Select(sc => new
            {
                id = sc[3],
                text = sc[3],
            });

            return this.Json(modifiedData);
        }

        [HttpPost("SubFunds/ViewEntitySE/{EntityId}/{ChosenDate}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel model)
        {
            SetModelValuesForSpecificView(model);

            if (model.Command == "Reset")
            {
                model.SelectTerm = "Quick Select";
                return this.View(model);
            }

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);


            model.Entity = this.subFundsService
                  .GetSubFundWithDateById(chosenDate, model.EntityId);

            if (model.SelectTerm == null)
            {
                if (isInSelectionMode)
                {
                    CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!isInSelectionMode)
                {
                    model.EntitySubEntities = this.subFundsService
                        .GetSubFund_ShareClasses(chosenDate, model.EntityId);
                }

                return this.View(model);
            }

            if (isInSelectionMode)
            {
                CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
            }

            else if (!isInSelectionMode)
            {
                model.EntitySubEntities = this.subFundsService
                    .GetSubFund_ShareClasses(chosenDate, model.EntityId);
            }

            if (model.SelectTerm != null)
            {
                model.EntitySubEntities = CreateTableView.AddTableToView(model.EntitySubEntities, model.SelectTerm.ToLower());
            }

            if (model.Entity != null && model.EntitySubEntities != null)
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

            string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\SubfundFile\";
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
                                                fileTypeId,
                                                model.ControllerName);

            return this.RedirectToAction("All");
        }

        //[HttpPost]
        //public IActionResult UploadAgreement(SpecificEntityViewModel model)
        //{
        //    SetModelValuesForSpecificView(model);

        //    var file = model.UploadEntityFileModel.FileToUpload;
        //    var startConnectionModel = model.UploadEntityFileModel.StartConnection;
        //    var endConnectionModel = model.UploadEntityFileModel.EndConnection;

        //    if (!ModelState.IsValid || file == null || file.Length == 0)
        //    {
        //        return this.Content("File not loaded");
        //    }

        //    string networkFileLocation = @"\\Pha-sql-01\sqlexpress\FileFolder\SubfundFile\";
        //    string path = $"{networkFileLocation}{file.FileName}";

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    var startConnection = DateTime.ParseExact(startConnectionModel, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    DateTime? endConnection = null;

        //    if (!string.IsNullOrEmpty(endConnectionModel))
        //    {
        //        endConnection = DateTime.ParseExact(endConnectionModel, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    }

        //    var fileTypeDesc = model.UploadEntityFileModel.FileType;
        //    int fileTypeId = this.context.TbDomFileType
        //            .Where(s => s.FiletypeDesc == fileTypeDesc)
        //            .Select(s => s.FiletypeId)
        //            .FirstOrDefault();

        //    this.entitiesFileService.AddDocumentToSpecificEntity(
        //                                        file.FileName,
        //                                        model.EntityId,
        //                                        startConnection,
        //                                        endConnection,
        //                                        fileTypeId,
        //                                        model.ControllerName);

        //    return this.RedirectToAction("All");
        //}

        [HttpPost]
        public FileStream ReadPdfFile(SpecificEntityViewModel model)
        {
            FileStream fs = null;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            var path = this.entitiesFileService.LoadEntityFileToDisplay(model.EntityId, model.ChosenDate, controllerName);

            if (this.HttpContext.Request.Form.ContainsKey("read_Pdf"))
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            }

            return fs;
        }

        [HttpPost]
        public FileStreamResult ExtractExcelSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.EntitySubEntities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (model.EntitySubEntities[0].Length > 16)
            {
                model.EntitySubEntities = this.subFundsService.PrepareSubFund_ShareClassesForPDFExtract(chosenDate);
            }

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.EntitySubEntities, chosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("SubFunds/EditSubFund/{EntityId}/{ChosenDate}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditSubFund(int entityId, string chosenDate)
        {
            var date = DateTime.Parse(chosenDate);

            EditSubFundBindingModel model = new EditSubFundBindingModel
            {
                EntityProperties = this.subFundsService.GetSubFundWithDateById(date, entityId),
                InitialDate = DateTime.Today,
                SubFundId = entityId,
            };

            SetModelValuesForEditView(model);

            SetViewDataValuesForSubFundSelectLists();

            this.ModelState.Clear();
            return this.View(model);
        }

        [HttpPost("SubFunds/EditSubFund/{EntityId}/{ChosenDate}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditSubFund(EditSubFundBindingModel model, int entityId, string chosenDate)
        {
            string returnUrl = $"/SubFunds/All/";

            if (!ModelState.IsValid)
            {
                if (model.EntityProperties == null)
                {
                    var date = DateTime.Parse(chosenDate);
                    model.EntityProperties = this.subFundsService.GetSubFundWithDateById(date, entityId);
                    SetModelValuesForEditView(model);
                    SetViewDataValuesForSubFundSelectLists();
                }
                return View(model ?? new EditSubFundBindingModel());
            }

            if (this.HttpContext.Request.Form.ContainsKey("update_button"))
            {
                List<int?> nullIntegerParameters = new List<int?>();

                string initialDate = model.InitialDate.ToString("yyyyMMdd");
                int sfId = model.SubFundId;
                string subFundName = model.SubFundName;

                int sfStatusId = this.context.TbDomSfStatus
                    .Where(s => s.StDesc == model.Status)
                    .Select(s => s.StId)
                    .FirstOrDefault();

                string cssfCode = model.CSSFCode;
                string faCode = model.FACode;
                string depCode = model.DBCode;
                string taCode = model.TACode;

                string firstNavDate = model.FirstNavDate?.ToString("yyyyMMdd");
                string lastNavDate = model.LastNavDate?.ToString("yyyyMMdd");
                string cssfAuthDate = model.CSSFAuthDate?.ToString("yyyyMMdd");
                string expiryDate = model.ExpiryDate?.ToString("yyyyMMdd");
                string leiCode = model.LEICode;

                int? cesrClassId = this.context.TbDomCesrClass
                    .Where(cc => cc.CDesc == model.CesrClass)
                    .Select(cc => cc.CcId)
                    .FirstOrDefault();

                int? geoFocusId = this.context.TbDomCssfGeographicalFocus
                    .Where(gf => gf.GfDesc == model.GeographicalFocus)
                    .Select(gf => gf.GfId)
                    .FirstOrDefault();

                int? glExpId = this.context.TbDomGlobalExposure
                    .Where(ge => ge.GeDesc == model.GlobalExposure)
                    .Select(ge => ge.GeId)
                    .FirstOrDefault();

                string currency = model.CurrencyCode;

                int? frequencyId = this.context.TbDomNavFrequency
                   .Where(f => f.NfDesc == model.NavFrequency)
                   .Select(f => f.NfId)
                   .FirstOrDefault();

                int? valuationId = this.context.TbDomValutationDate
                   .Where(v => v.VdDesc == model.ValuationDate)
                   .Select(v => v.VdId)
                   .FirstOrDefault();

                int? calculationId = this.context.TbDomCalculationDate
                   .Where(cal => cal.CdDesc == model.CalculationDate)
                   .Select(cal => cal.CdId)
                   .FirstOrDefault();

                bool isDerivative = false;

                if (model.Derivatives == "Yes")
                {
                    isDerivative = true;
                }

                int? derivMarketId = this.context.TbDomDerivMarket
                  .Where(dm => dm.DmDesc == model.DerivMarket)
                  .Select(dm => dm.DmId)
                  .FirstOrDefault();

                int? derivPurposeId = this.context.TbDomDerivPurpose
                  .Where(dp => dp.DpDesc == model.DerivPurpose)
                  .Select(dp => dp.DpId)
                  .FirstOrDefault();

                int? principalAssetId = this.context.TbDomCssfPrincipalAssetClass
                   .Where(pa => pa.PacDesc == model.PrincipalAssetClass)
                   .Select(pa => pa.PacId)
                   .FirstOrDefault();

                int? typeMarketId = this.context.TbDomTypeOfMarket
                   .Where(tm => tm.TomDesc == model.TypeOfMarket)
                   .Select(tm => tm.TomId)
                   .FirstOrDefault();

                int? principalInvStrId = this.context.TbDomPrincipalInvestmentStrategy
                   .Where(pi => pi.PisDesc == model.PrincipalInvestmentStrategy)
                   .Select(pi => pi.PisId)
                   .FirstOrDefault();

                string clearingCode = model.ClearingCode;

                int? catMorningStarId = this.context.TbDomSfCatMorningstar
                   .Where(cm => cm.CMorningstarDesc == model.SfCatMorningStar)
                   .Select(cm => cm.CMorningstarId)
                   .FirstOrDefault();

                int? catSixId = this.context.TbDomSfCatSix
                   .Where(cs => cs.CatSixDesc == model.SfCatSix)
                   .Select(cs => cs.CatSixId)
                   .FirstOrDefault();

                int? catBloombergId = this.context.TbDomSfCatBloomberg
                   .Where(cb => cb.CatBloombergDesc == model.SfCatBloomberg)
                   .Select(cb => cb.CatBloombergId)
                   .FirstOrDefault();

                SetZeroValuesToNull(nullIntegerParameters, cesrClassId, geoFocusId, glExpId,
                                    frequencyId, valuationId, calculationId, derivMarketId,
                                    derivPurposeId, principalAssetId, typeMarketId, principalInvStrId,
                                    catMorningStarId, catSixId, catBloombergId);

                string comment = model.CommentArea;
                string commentTitle = model.CommentTitle;

                this.subFundsService.EditSubFund(sfId, initialDate, subFundName, cssfCode, faCode,
                                                depCode, taCode, firstNavDate, lastNavDate, cssfAuthDate,
                                                expiryDate, sfStatusId, leiCode, nullIntegerParameters[0], nullIntegerParameters[1],
                                                nullIntegerParameters[2], currency, nullIntegerParameters[3], nullIntegerParameters[4],
                                                nullIntegerParameters[5], isDerivative, nullIntegerParameters[6], nullIntegerParameters[7],
                                                nullIntegerParameters[8], nullIntegerParameters[9], nullIntegerParameters[10],
                                                clearingCode, nullIntegerParameters[11], nullIntegerParameters[12],
                                                nullIntegerParameters[13], comment, commentTitle);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateSubFund()
        {
            CreateSubFundBindingModel model = new CreateSubFundBindingModel
            {
                InitialDate = DateTime.Today,
            };

            SetViewDataValuesForSubFundSelectLists();

            this.ModelState.Clear();
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSubFund(CreateSubFundBindingModel model)
        {
            string returnUrl = "/SubFunds/All";

            SetViewDataValuesForSubFundSelectLists();

            model.ExistingEntitiesNames = this.subFundsService.GetAllSubFundsNames();

            if (!this.ModelState.IsValid || model.ExistingEntitiesNames.Any(sf => sf == model.SubFundName))
            {
                return this.View(model ?? new CreateSubFundBindingModel());
            }

            if (this.HttpContext.Request.Form.ContainsKey("create_button"))
            {
                List<int?> nullIntegerParameters = new List<int?>();

                string initialDate = model.InitialDate.ToString("yyyyMMdd");
                string endDate = model.EndDate?.ToString("yyyyMMdd");
                string subFundName = model.SubFundName;

                int sfStatusId = this.context.TbDomSfStatus
                    .Where(s => s.StDesc == model.Status)
                    .Select(s => s.StId)
                    .FirstOrDefault();

                string cssfCode = model.CSSFCode;
                string faCode = model.FACode;
                string depCode = model.DBCode;
                string taCode = model.TACode;

                string firstNavDate = model.FirstNavDate?.ToString("yyyyMMdd");
                string lastNavDate = model.LastNavDate?.ToString("yyyyMMdd");
                string cssfAuthDate = model.CSSFAuthDate?.ToString("yyyyMMdd");
                string expiryDate = model.ExpiryDate?.ToString("yyyyMMdd");

                string leiCode = model.LEICode;

                int? cesrClassId = this.context.TbDomCesrClass
                    .Where(cc => cc.CDesc == model.CesrClass)
                    .Select(cc => cc.CcId)
                    .FirstOrDefault();

                int? geoFocusId = this.context.TbDomCssfGeographicalFocus
                    .Where(gf => gf.GfDesc == model.GeographicalFocus)
                    .Select(gf => gf.GfId)
                    .FirstOrDefault();

                int? glExpId = this.context.TbDomGlobalExposure
                    .Where(ge => ge.GeDesc == model.GlobalExposure)
                    .Select(ge => ge.GeId)
                    .FirstOrDefault();

                string currency = model.CurrencyCode;

                int? frequencyId = this.context.TbDomNavFrequency
                   .Where(f => f.NfDesc == model.NavFrequency)
                   .Select(f => f.NfId)
                   .FirstOrDefault();

                int? valuationId = this.context.TbDomValutationDate
                   .Where(v => v.VdDesc == model.ValuationDate)
                   .Select(v => v.VdId)
                   .FirstOrDefault();

                int? calculationId = this.context.TbDomCalculationDate
                   .Where(cal => cal.CdDesc == model.CalculationDate)
                   .Select(cal => cal.CdId)
                   .FirstOrDefault();

                bool isDerivative = false;

                if (model.Derivatives == "Yes")
                {
                    isDerivative = true;
                }

                int? derivMarketId = this.context.TbDomDerivMarket
                  .Where(dm => dm.DmDesc == model.DerivMarket)
                  .Select(dm => dm.DmId)
                  .FirstOrDefault();

                int? derivPurposeId = this.context.TbDomDerivPurpose
                  .Where(dp => dp.DpDesc == model.DerivPurpose)
                  .Select(dp => dp.DpId)
                  .FirstOrDefault();

                int? principalAssetId = this.context.TbDomCssfPrincipalAssetClass
                   .Where(pa => pa.PacDesc == model.PrincipalAssetClass)
                   .Select(pa => pa.PacId)
                   .FirstOrDefault();

                int? typeMarketId = this.context.TbDomTypeOfMarket
                   .Where(tm => tm.TomDesc == model.TypeOfMarket)
                   .Select(tm => tm.TomId)
                   .FirstOrDefault();

                int? principalInvStrId = this.context.TbDomPrincipalInvestmentStrategy
                   .Where(pi => pi.PisDesc == model.PrincipalInvestmentStrategy)
                   .Select(pi => pi.PisId)
                   .FirstOrDefault();

                string clearingCode = model.ClearingCode;

                int? catMorningStarId = this.context.TbDomSfCatMorningstar
                   .Where(cm => cm.CMorningstarDesc == model.SfCatMorningStar)
                   .Select(cm => cm.CMorningstarId)
                   .FirstOrDefault();

                int? catSixId = this.context.TbDomSfCatSix
                   .Where(cs => cs.CatSixDesc == model.SfCatSix)
                   .Select(cs => cs.CatSixId)
                   .FirstOrDefault();

                int? catBloombergId = this.context.TbDomSfCatBloomberg
                   .Where(cb => cb.CatBloombergDesc == model.SfCatBloomberg)
                   .Select(cb => cb.CatBloombergId)
                   .FirstOrDefault();

                int fundContainerId = this.context.TbHistoryFund
                   .Where(fc => fc.FOfficialFundName == model.FundContainer)
                   .Select(fc => fc.FId)
                   .FirstOrDefault();

                SetZeroValuesToNull(nullIntegerParameters, cesrClassId, geoFocusId, glExpId,
                                    frequencyId, valuationId, calculationId, derivMarketId,
                                    derivPurposeId, principalAssetId, typeMarketId, principalInvStrId,
                                    catMorningStarId, catSixId, catBloombergId);

                this.subFundsService.CreateSubFund(initialDate, endDate, subFundName, cssfCode, faCode,
                                                depCode, taCode, firstNavDate, lastNavDate, cssfAuthDate,
                                                expiryDate, sfStatusId, leiCode, nullIntegerParameters[0], nullIntegerParameters[1],
                                                nullIntegerParameters[2], currency, nullIntegerParameters[3], nullIntegerParameters[4],
                                                nullIntegerParameters[5], isDerivative, nullIntegerParameters[6], nullIntegerParameters[7],
                                                nullIntegerParameters[8], nullIntegerParameters[9], nullIntegerParameters[10],
                                                clearingCode, nullIntegerParameters[11], nullIntegerParameters[12],
                                                nullIntegerParameters[13], fundContainerId);
            }
            // End of if statement

            return this.LocalRedirect(returnUrl);
        }

        private void CallAllEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.subFundsService.GetAllSubFundsWithSelectedViewAndDate(
                model.PreSelectedColumns,
                model.SelectedColumns,
                chosenDate);
        }

        private void CallActiveEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.subFundsService.GetAllActiveSubFundsWithSelectedViewAndDate(
                                        model.PreSelectedColumns,
                                        model.SelectedColumns,
                                        chosenDate);
        }

        private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime chosenDate)
        {
            model.EntitySubEntities = this.subFundsService.GetSubFund_ShareClassesWithSelectedViewAndDate(
                                    model.PreSelectedColumns,
                                    model.SelectedColumns,
                                    chosenDate,
                                    model.EntityId);
        }

        private string GetFileNameFromFilePath(int entityId, string chosenDate, string controllerName)
        {
            return this.entitiesFileService.LoadEntityFileToDisplay(entityId, chosenDate, controllerName).Split('\\').Last();
        }

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            var date = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            model.Entity = this.subFundsService.GetSubFundWithDateById(date, entityId);
            model.EntitySubEntities = this.subFundsService.GetSubFund_ShareClasses(date, entityId);
            model.EntitiesHeadersForColumnSelection = this.subFundsService
                                                                    .GetSubFund_ShareClasses(date, entityId)
                                                                    .Take(1)
                                                                    .ToList();
            model.ProspectusNameToDisplay = GetFileNameFromFilePath
                (entityId, model.ChosenDate, model.ControllerName)
                .Split(".")[0];
            model.DistinctDocumentsNamesToDisplay = this.subFundsService.GetDistinctSubFundDocuments(entityId);
            model.DistinctAgreementsNamesToDisplay = this.subFundsService.GetDistinctSubFundAgreements(date, entityId);
            model.AllAgreementsNamesToDisplay = this.subFundsService.GetAllSubFundAgreements(date, entityId);
            model.EntityTimeline = this.subFundsService.GetSubFundTimeline(entityId);
            model.EntityDocuments = this.subFundsService.GetAllSubFundDocumens(entityId);
            model.BaseEntityName = this.subFundsService.GetSubFund_FundContainer(date, entityId)[1][1];
            model.BaseEntityId = this.subFundsService.GetSubFund_FundContainer(date, entityId)[1][0];

            model.StartConnection = model.Entity[1][0];
            model.EndConnection = model.Entity[1][1];

            this.ViewData["FileTypes"] = this.subfundsSelectListService.GetAllSubFundFileTypes();
            this.ViewData["AgreementsFileTypes"] = this.subfundsSelectListService.GetAllAgreementsFileTypes();
            this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }

        private static void SetZeroValuesToNull(
                                            List<int?> nullIntegerParameters, int? cesrClassId, int? geoFocusId,
                                            int? glExpId, int? frequencyId, int? valuationId, int? calculationId,
                                            int? derivMarketId, int? derivPurposeId, int? principalAssetId,
                                            int? typeMarketId, int? principalInvStrId, int? catMorningStarId,
                                            int? catSixId, int? catBloombergId)
        {
            nullIntegerParameters.Add(cesrClassId);
            nullIntegerParameters.Add(geoFocusId);
            nullIntegerParameters.Add(glExpId);
            nullIntegerParameters.Add(frequencyId);
            nullIntegerParameters.Add(valuationId);
            nullIntegerParameters.Add(calculationId);
            nullIntegerParameters.Add(derivMarketId);
            nullIntegerParameters.Add(derivPurposeId);
            nullIntegerParameters.Add(principalAssetId);
            nullIntegerParameters.Add(typeMarketId);
            nullIntegerParameters.Add(principalInvStrId);
            nullIntegerParameters.Add(catMorningStarId);
            nullIntegerParameters.Add(catSixId);
            nullIntegerParameters.Add(catBloombergId);

            for (int i = 0; i < nullIntegerParameters.Count; i++)
            {
                if (nullIntegerParameters[i] == 0)
                {
                    nullIntegerParameters[i] = null;
                }
            }
        }
        private static void SetModelValuesForEditView(SubFundBindingModel model)
        {
            model.SubFundName = model.EntityProperties[1][3];
            model.CSSFCode = model.EntityProperties[1][5];
            model.FACode = model.EntityProperties[1][6];
            model.DBCode = model.EntityProperties[1][7];
            model.TACode = model.EntityProperties[1][8];

            if (!string.IsNullOrEmpty(model.EntityProperties[1][9]))
            {
                model.FirstNavDate = DateTime.Parse(model.EntityProperties[1][9], CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(model.EntityProperties[1][10]))
            {
                model.LastNavDate = DateTime.Parse(model.EntityProperties[1][10], CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(model.EntityProperties[1][11]))
            {
                model.CSSFAuthDate = DateTime.Parse(model.EntityProperties[1][11], CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(model.EntityProperties[1][12]))
            {
                model.ExpiryDate = DateTime.Parse(model.EntityProperties[1][12], CultureInfo.InvariantCulture);
            }

            model.LEICode = model.EntityProperties[1][14];
            model.Derivatives = model.EntityProperties[1][22];
            model.ClearingCode = model.EntityProperties[1][30];
        }

        private void SetViewDataValuesForSubFundSelectLists()
        {
            this.ViewData["Status"] = this.subfundsSelectListService.GetAllTbDomSFStatus();
            this.ViewData["CesrClass"] = this.subfundsSelectListService.GetAllTbDomCesrClass();
            this.ViewData["GeographicalFocus"] = this.subfundsSelectListService.GetAllTbDomGeographicalFocus();
            this.ViewData["GlobalExposure"] = this.subfundsSelectListService.GetAllTbDomGlobalExposure();
            this.ViewData["CurrencyCode"] = this.subfundsSelectListService.GetAllTbDomCurrencyCode();
            this.ViewData["NavFrequency"] = this.subfundsSelectListService.GetAllTbDomFrequency();
            this.ViewData["ValuationDate"] = this.subfundsSelectListService.GetAllTbDomValuationDate();
            this.ViewData["CalculationDate"] = this.subfundsSelectListService.GetAllTbDomCalculationDate();
            this.ViewData["DerivMarket"] = this.subfundsSelectListService.GetAllTbDomDerivMarket();
            this.ViewData["DerivPurpose"] = this.subfundsSelectListService.GetAllTbDomDerivPurpose();
            this.ViewData["PrincipalAssetClass"] = this.subfundsSelectListService.GetAllTbDomPrincipalAssetClass();
            this.ViewData["TypeOfMarket"] = this.subfundsSelectListService.GetAllTbDomTypeOfMarket();
            this.ViewData["PrincipalInvestmentStrategy"] = this.subfundsSelectListService.GetAllTbDomPrincipalInvestmentStrategy();
            this.ViewData["SfCatMorningStar"] = this.subfundsSelectListService.GetAllTbDomSfCatMorningStar();
            this.ViewData["SfCatSix"] = this.subfundsSelectListService.GetAllTbDomSfCatSix();
            this.ViewData["SfCatBloomberg"] = this.subfundsSelectListService.GetAllTbDomSfCatBloomberg();

            this.ViewData["FundContainer"] = this.context.TbHistoryFund.Select(f => f.FOfficialFundName).ToList();
        }
    }
}