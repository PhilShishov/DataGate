namespace Pharus.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class ShareClassesController : Controller
    {
        private readonly ISubFundsService _subFundsService;
        private readonly ISubFundsSelectListService _subfundsSelectListService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SubFundsController(
            ISubFundsService subFundsService,
            ISubFundsSelectListService subfundsSelectListService,
            IHostingEnvironment hostingEnvironment)
        {
            this._subFundsService = subFundsService;
            this._subfundsSelectListService = subfundsSelectListService;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveEntitiesViewModel
            {
                ActiveEntities = this._subFundsService.GetAllActiveSubFunds()
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(ActiveEntitiesViewModel model)
        {
            ModelState.Clear();
            model.ActiveEntities = this._subFundsService.GetAllActiveSubFunds();

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.ActiveEntities = this._subFundsService.GetAllActiveSubFunds(model.ChosenDate);
                }
            }

            else if (model.Command.Equals("Filter"))
            {
                if (model.SearchString == null)
                {
                    return this.View(model);
                }

                model.ActiveEntities = new List<string[]>();

                var tableHeaders = this._subFundsService.GetAllActiveSubFunds().Take(1).ToList();
                var tableFundsWithoutHeaders = this._subFundsService.GetAllActiveSubFunds().Skip(1).ToList();

                CreateTableView.AddHeadersToView(model.ActiveEntities, tableHeaders);

                CreateTableView.AddTableToView(model.ActiveEntities, tableFundsWithoutHeaders, model.SearchString.ToLower());
            }

            if (model.ActiveEntities != null)
            {
                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public FileStreamResult ExtractExcelEntities(ActiveEntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.ActiveEntities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractExcelSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.AESubEntities, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfEntities(ActiveEntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.ActiveEntities, model.ChosenDate, _hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.AESubEntities, model.ChosenDate, _hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                ActiveEntity = this._subFundsService.GetActiveSubFundById(entityId),
                AESubEntities = this._subFundsService.GetSubFundShareClasses(entityId)
            };

            return this.View(viewModel);
        }

        [HttpPost("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.ActiveEntity = this._subFundsService.GetActiveSubFundById(viewModel.EntityId);
            viewModel.AESubEntities = this._subFundsService.GetSubFundShareClasses(viewModel.EntityId);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveEntity = this._subFundsService.GetActiveSubFundById(viewModel.ChosenDate, viewModel.EntityId);
                }
            }

            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchString == null)
                {
                    return this.View(viewModel);
                }

                viewModel.AESubEntities = new List<string[]>();

                var tableHeaders = this._subFundsService.GetSubFundShareClasses(viewModel.EntityId).Take(1).ToList();
                var tableFundsWithoutHeaders = this._subFundsService.GetSubFundShareClasses(viewModel.EntityId).Skip(1).ToList();

                CreateTableView.AddHeadersToView(viewModel.AESubEntities, tableHeaders);

                CreateTableView.AddTableToView(viewModel.AESubEntities, tableFundsWithoutHeaders, viewModel.SearchString.ToLower());
            }

            if (viewModel.ActiveEntity != null && viewModel.AESubEntities != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpGet("SubFunds/EditSubFund/{EntityId}")]
        public IActionResult EditSubFund(int entityId)
        {
            EditSubFundBindingModel model = new EditSubFundBindingModel
            {
                EntityProperties = this._subFundsService.GetActiveSubFundWithDateById(entityId),
                CalculationDate = new SelectList(this._subfundsSelectListService.GetAllTbDomCalculationDate()),
                CesrClass = new SelectList(this._subfundsSelectListService.GetAllTbDomCesrClass()),
                CurrencyCode = new SelectList(this._subfundsSelectListService.GetAllTbDomCurrencyCode()),
                DerivMarket = new SelectList(this._subfundsSelectListService.GetAllTbDomDerivMarket()),
                DerivPurpose = new SelectList(this._subfundsSelectListService.GetAllTbDomDerivPurpose()),
                Frequency = new SelectList(this._subfundsSelectListService.GetAllTbDomFrequency()),
                GeographicalFocus = new SelectList(this._subfundsSelectListService.GetAllTbDomGeographicalFocus()),
                GlobalExposure = new SelectList(this._subfundsSelectListService.GetAllTbDomGlobalExposure()),
                PrincipalAssetClass = new SelectList(this._subfundsSelectListService.GetAllTbDomPrincipalAssetClass()),
                PrincipalInvestmentStrategy = new SelectList(this._subfundsSelectListService.GetAllTbDomPrincipalInvestmentStrategy()),
                SfCatBloomberg = new SelectList(this._subfundsSelectListService.GetAllTbDomSfCatBloomberg()),
                SfCatMorningStar = new SelectList(this._subfundsSelectListService.GetAllTbDomSfCatMorningStar()),
                SfCatSix = new SelectList(this._subfundsSelectListService.GetAllTbDomSfCatSix()),
                SfStatus = new SelectList(this._subfundsSelectListService.GetAllTbDomSFStatus()),
                TypeOfMarket = new SelectList(this._subfundsSelectListService.GetAllTbDomTypeOfMarket()),
                ValuationDate = new SelectList(this._subfundsSelectListService.GetAllTbDomValuationDate())
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditSubFund(EditSubFundBindingModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model ?? new EditFundBindingModel());
            //}

            int entityId = int.Parse(model.EntityProperties[1][0]);
            string returnUrl = $"/SubFunds/ViewSubFundSC/{entityId}";

            var subFund = this._subFundsService.GetActiveSubFundById(entityId);

            if (HttpContext.Request.Form.ContainsKey("modify_button"))
            {
                for (int row = 1; row < subFund.Count; row++)
                {
                    for (int col = 0; col < subFund[row].Length; col++)
                    {
                        subFund[row][col] = model.EntityProperties[row][col];
                    }
                }

                return LocalRedirect(returnUrl);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult NewSubFund()
        {
            EditSubFundBindingModel model = new EditSubFundBindingModel
            {
                EntityProperties = this._subFundsService.GetAllActiveSubFunds(),
                CalculationDate = new SelectList(this._subfundsSelectListService.GetAllTbDomCalculationDate()),
                CesrClass = new SelectList(this._subfundsSelectListService.GetAllTbDomCesrClass()),
                CurrencyCode = new SelectList(this._subfundsSelectListService.GetAllTbDomCurrencyCode()),
                DerivMarket = new SelectList(this._subfundsSelectListService.GetAllTbDomDerivMarket()),
                DerivPurpose = new SelectList(this._subfundsSelectListService.GetAllTbDomDerivPurpose()),
                Frequency = new SelectList(this._subfundsSelectListService.GetAllTbDomFrequency()),
                GeographicalFocus = new SelectList(this._subfundsSelectListService.GetAllTbDomGeographicalFocus()),
                GlobalExposure = new SelectList(this._subfundsSelectListService.GetAllTbDomGlobalExposure()),
                PrincipalAssetClass = new SelectList(this._subfundsSelectListService.GetAllTbDomPrincipalAssetClass()),
                PrincipalInvestmentStrategy = new SelectList(this._subfundsSelectListService.GetAllTbDomPrincipalInvestmentStrategy()),
                SfCatBloomberg = new SelectList(this._subfundsSelectListService.GetAllTbDomSfCatBloomberg()),
                SfCatMorningStar = new SelectList(this._subfundsSelectListService.GetAllTbDomSfCatMorningStar()),
                SfCatSix = new SelectList(this._subfundsSelectListService.GetAllTbDomSfCatSix()),
                SfStatus = new SelectList(this._subfundsSelectListService.GetAllTbDomSFStatus()),
                TypeOfMarket = new SelectList(this._subfundsSelectListService.GetAllTbDomTypeOfMarket()),
                ValuationDate = new SelectList(this._subfundsSelectListService.GetAllTbDomValuationDate())
            };

            return this.View(model);
        }
    }
}