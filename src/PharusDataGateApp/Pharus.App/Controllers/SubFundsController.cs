namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Services.SubFunds.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.SubFunds;
    using Microsoft.AspNetCore.Http;

    [Authorize]
    public class SubFundsController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly ISubFundsService subFundsService;
        private readonly ISubFundsSelectListService subfundsSelectListService;
        private readonly ISubFundsFileService subFundsFileService;
        private readonly IHostingEnvironment hostingEnvironment;

        public SubFundsController(
            Pharus_vFinale_Context context,
            ISubFundsService subFundsService,
            ISubFundsSelectListService subfundsSelectListService,
            ISubFundsFileService subFundsFileService,
            IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.subFundsService = subFundsService;
            this.subfundsSelectListService = subfundsSelectListService;
            this.subFundsFileService = subFundsFileService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
            };

            GetAllActiveEntitiesUtility.GetAllActiveSubFundsWithHeaders(model, this.subFundsService);

            this.ModelState.Clear();
            return this.View(model);
        }

        public JsonResult AutoCompleteSubFundList(string searchTerm)
        {
            var result = this.context.TbHistorySubFund.ToList();
            if (searchTerm != null)
            {
                result = this.context.TbHistorySubFund.Where(s => s.SfOfficialSubFundName.Contains(searchTerm)).ToList();
            }

            var modifiedData = result.Select(s => new
            {
                id = s.SfOfficialSubFundName,
                text = s.SfOfficialSubFundName,
            });
            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            GetAllActiveEntitiesUtility.GetAllActiveSubFundsWithHeaders(model, this.subFundsService);

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    if (model.IsActive)
                    {
                        GetAllActiveEntitiesUtility.GetAllActiveSubFundsWithHeaders(model, this.subFundsService);
                    }
                    else
                    {
                        model.Entities = this.subFundsService.GetAllSubFunds(chosenDate);
                    }
                }
            }
            else if (model.Command.Equals("Search"))
            {
                if (model.SearchTerm == null)
                {
                    return this.View(model);
                }

                model.Entities = new List<string[]>();

                var tableHeaders = this.subFundsService
                    .GetAllSubFunds()
                    .Take(1)
                    .ToList();

                List<string[]> tableWithoutHeaders = null;

                if (model.IsActive)
                {
                    tableWithoutHeaders = this.subFundsService
                        .GetAllSubFunds(chosenDate)
                        .Skip(1)
                        .Where(f => f.Contains("Active"))
                        .ToList();
                }
                else
                {
                    tableWithoutHeaders = this.subFundsService
                        .GetAllSubFunds()
                        .Skip(1)
                        .ToList();
                }

                CreateTableView.AddHeadersToView(model.Entities, tableHeaders);

                CreateTableView.AddTableToView(model.Entities, tableWithoutHeaders, model.SearchTerm.ToLower());
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
            FileStreamResult fileStreamResult = null;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

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
                Entity = this.subFundsService.GetSubFundById(entityId),
                EntitySubEntities = this.subFundsService.GetSubFund_ShareClasses(entityId),
                EntityTimeline = this.subFundsService.GetSubFundTimeline(entityId),
                EntityDocuments = this.subFundsService.GetAllSubFundDocumens(entityId),
                BaseEntityName = this.subFundsService.GetSubFund_FundContainer(entityId)[1][1],
                BaseEntityId = this.subFundsService.GetSubFund_FundContainer(entityId)[1][0],
            };

            this.ViewData["FileTypes"] = this.subfundsSelectListService.GetAllSubFundFileTypes();

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

        private string GetFileNameFromFilePath(int entityId, string chosenDate)
        {
            return this.subFundsFileService.LoadSubFundFileToDisplay(entityId, chosenDate).Split('\\').Last();
        }

        public JsonResult AutoCompleteShareClassesList(string searchTerm, int entityId)
        {
            var entitiesToSearch = this.subFundsService.GetSubFund_ShareClasses(entityId).Skip(1).ToList();

            if (searchTerm != null)
            {
                entitiesToSearch = entitiesToSearch.Where(s => s[3].ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            var modifiedData = entitiesToSearch.Select(s => new
            {
                id = s[3],
                text = s[3],
            });

            return this.Json(modifiedData);
        }

        [HttpPost("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.Entity = this.subFundsService.GetSubFundById(viewModel.EntityId);
            viewModel.EntitySubEntities = this.subFundsService.GetSubFund_ShareClasses(viewModel.EntityId);

            var chosenDate = DateTime.ParseExact(viewModel.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.Entity = this.subFundsService.GetSubFundById(chosenDate, viewModel.EntityId);
                }
            }
            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchTerm == null)
                {
                    return this.View(viewModel);
                }

                viewModel.EntitySubEntities = new List<string[]>();

                var tableHeaders = this.subFundsService.GetSubFund_ShareClasses(viewModel.EntityId).Take(1).ToList();
                var tableFundsWithoutHeaders = this.subFundsService.GetSubFund_ShareClasses(viewModel.EntityId).Skip(1).ToList();

                CreateTableView.AddHeadersToView(viewModel.EntitySubEntities, tableHeaders);

                CreateTableView.AddTableToView(viewModel.EntitySubEntities, tableFundsWithoutHeaders, viewModel.SearchTerm.ToLower());
            }

            if (viewModel.Entity != null && viewModel.EntitySubEntities != null)
            {
                return this.View(viewModel);
            }

            return this.View();
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

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.EntitySubEntities, chosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        //[HttpGet("SubFunds/EditSubFund/{EntityId}")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult EditSubFund(int entityId)
        //{
        //    SubFundBindingModel model = new SubFundBindingModel
        //    {
        //        EntityProperties = this.subFundsService.GetSubFundWithDateById(entityId),
        //        CalculationDate = new SelectList(this.subfundsSelectListService.GetAllTbDomCalculationDate()),
        //        CesrClass = new SelectList(this.subfundsSelectListService.GetAllTbDomCesrClass()),
        //        CurrencyCode = new SelectList(this.subfundsSelectListService.GetAllTbDomCurrencyCode()),
        //        DerivMarket = new SelectList(this.subfundsSelectListService.GetAllTbDomDerivMarket()),
        //        DerivPurpose = new SelectList(this.subfundsSelectListService.GetAllTbDomDerivPurpose()),
        //        Frequency = new SelectList(this.subfundsSelectListService.GetAllTbDomFrequency()),
        //        GeographicalFocus = new SelectList(this.subfundsSelectListService.GetAllTbDomGeographicalFocus()),
        //        GlobalExposure = new SelectList(this.subfundsSelectListService.GetAllTbDomGlobalExposure()),
        //        PrincipalAssetClass = new SelectList(this.subfundsSelectListService.GetAllTbDomPrincipalAssetClass()),
        //        PrincipalInvestmentStrategy = new SelectList(this.subfundsSelectListService.GetAllTbDomPrincipalInvestmentStrategy()),
        //        SfCatBloomberg = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatBloomberg()),
        //        SfCatMorningStar = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatMorningStar()),
        //        SfCatSix = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatSix()),
        //        SfStatus = new SelectList(this.subfundsSelectListService.GetAllTbDomSFStatus()),
        //        TypeOfMarket = new SelectList(this.subfundsSelectListService.GetAllTbDomTypeOfMarket()),
        //        ValuationDate = new SelectList(this.subfundsSelectListService.GetAllTbDomValuationDate()),
        //    };

        //    return this.View(model);
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult EditSubFund(SubFundBindingModel model)
        //{
        //    // if (!ModelState.IsValid)
        //    // {
        //    //    return View(model ?? new EditFundBindingModel());
        //    // }
        //    int entityId = int.Parse(model.EntityProperties[1][0]);
        //    string returnUrl = $"/SubFunds/ViewSubFundSC/{entityId}";

        //    var subFund = this.subFundsService.GetSubFundById(entityId);

        //    if (this.HttpContext.Request.Form.ContainsKey("modify_button"))
        //    {
        //        for (int row = 1; row < subFund.Count; row++)
        //        {
        //            for (int col = 0; col < subFund[row].Length; col++)
        //            {
        //                subFund[row][col] = model.EntityProperties[row][col];
        //            }
        //        }

        //        return this.LocalRedirect(returnUrl);
        //    }

        //    return this.LocalRedirect(returnUrl);
        //}

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

            model.ExistingSubFundNames = this.subFundsService.GetAllSubFundsNames();

            if (!this.ModelState.IsValid || model.ExistingSubFundNames.Any(sf => sf == model.SubFundName))
            {
                return this.View(model ?? new CreateSubFundBindingModel());
            }

            string initialDate = model.InitialDate.ToString("yyyyMMdd");
            string endDate = model.EndDate?.ToString("yyyyMMdd");
            string firstNavDate = model.EndDate?.ToString("yyyyMMdd");
            string lastNavDate = model.EndDate?.ToString("yyyyMMdd");
            string cssfAuthDate = model.EndDate?.ToString("yyyyMMdd");
            string expiryDate = model.EndDate?.ToString("yyyyMMdd");

            if (this.HttpContext.Request.Form.ContainsKey("create_button"))
            {
                string subFundName = model.SubFundName;
                string cssfCode = model.CSSFCode;
                string faCode = model.FACode;
                string depCode = model.DBCode;
                string taCode = model.TACode;

                int sfStatusId = this.context.TbDomSfStatus
                    .Where(s => s.StDesc == model.SfStatus)
                    .Select(s => s.StId)
                    .FirstOrDefault();

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

                string currency = this.context.TbDomIsoCurrency
                   .Where(c => c.IsoCcyDesc == model.CurrencyCode)
                   .Select(c => c.IsoCcyCode)
                   .FirstOrDefault();

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

                this.subFundsService.CreateSubFund(initialDate, endDate, subFundName, cssfCode, faCode,
                                                depCode, taCode, firstNavDate, lastNavDate, cssfAuthDate,
                                                expiryDate, sfStatusId, leiCode, cesrClassId, geoFocusId,
                                                glExpId, currency, frequencyId, valuationId, calculationId,
                                                isDerivative, derivMarketId, derivPurposeId, principalAssetId,
                                                typeMarketId, principalInvStrId, clearingCode, catMorningStarId,
                                                catSixId, catBloombergId, fundContainerId);
            }
            // End of if statement

            return this.LocalRedirect(returnUrl);
        }

        private void SetViewDataValuesForSubFundSelectLists()
        {
            this.ViewData["SfStatus"] = this.subfundsSelectListService.GetAllTbDomSFStatus();
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