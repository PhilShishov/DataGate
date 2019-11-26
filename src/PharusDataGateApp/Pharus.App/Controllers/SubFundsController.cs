namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.SubFunds;

    public class SubFundsController : Controller
    {
        private readonly Pharus_vFinaleContext context;
        private readonly ISubFundsService subFundsService;
        private readonly ISubFundsSelectListService subfundsSelectListService;
        private readonly IHostingEnvironment hostingEnvironment;

        public SubFundsController(
            Pharus_vFinaleContext context,
            ISubFundsService subFundsService,
            ISubFundsSelectListService subfundsSelectListService,
            IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.subFundsService = subFundsService;
            this.subfundsSelectListService = subfundsSelectListService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public JsonResult AutoCompleteFundList(string searchTerm)
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

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveEntitiesViewModel
            {
                ActiveEntities = this.subFundsService.GetAllActiveSubFunds(),
                IsActive = true,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(ActiveEntitiesViewModel model)
        {
            this.ModelState.Clear();
            model.ActiveEntities = this.subFundsService.GetAllActiveSubFunds();

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    if (model.IsActive)
                    {
                        GetAllActiveEntitiesWithHeaders.GetAllActiveSubFundsWithHeaders(model, this.subFundsService);
                    }
                    else
                    {
                        model.ActiveEntities = this.subFundsService.GetAllActiveSubFunds(model.ChosenDate);
                    }
                }
            }
            else if (model.Command.Equals("Search"))
            {
                if (model.SearchTerm == null)
                {
                    return this.View(model);
                }

                model.ActiveEntities = new List<string[]>();

                var tableHeaders = this.subFundsService
                    .GetAllActiveSubFunds()
                    .Take(1)
                    .ToList();
                var tableFundsWithoutHeaders = this.subFundsService.GetAllActiveSubFunds().Skip(1).ToList();

                CreateTableView.AddHeadersToView(model.ActiveEntities, tableHeaders);

                CreateTableView.AddTableToView(model.ActiveEntities, tableFundsWithoutHeaders, model.SearchTerm.ToLower());
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

            if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
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

            if (this.HttpContext.Request.Form.ContainsKey("extract_Excel"))
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

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.ActiveEntities, model.ChosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (this.HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.AESubEntities, model.ChosenDate, this.hostingEnvironment, typeName, controllerName);
            }

            return fileStreamResult;
        }

        [HttpGet("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                ActiveEntity = this.subFundsService.GetActiveSubFundById(entityId),
                AESubEntities = this.subFundsService.GetSubFundShareClasses(entityId),
            };

            return this.View(viewModel);
        }

        [HttpPost("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.ActiveEntity = this.subFundsService.GetActiveSubFundById(viewModel.EntityId);
            viewModel.AESubEntities = this.subFundsService.GetSubFundShareClasses(viewModel.EntityId);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveEntity = this.subFundsService.GetActiveSubFundById(viewModel.ChosenDate, viewModel.EntityId);
                }
            }
            else if (viewModel.Command.Equals("Filter"))
            {
                if (viewModel.SearchTerm == null)
                {
                    return this.View(viewModel);
                }

                viewModel.AESubEntities = new List<string[]>();

                var tableHeaders = this.subFundsService.GetSubFundShareClasses(viewModel.EntityId).Take(1).ToList();
                var tableFundsWithoutHeaders = this.subFundsService.GetSubFundShareClasses(viewModel.EntityId).Skip(1).ToList();

                CreateTableView.AddHeadersToView(viewModel.AESubEntities, tableHeaders);

                CreateTableView.AddTableToView(viewModel.AESubEntities, tableFundsWithoutHeaders, viewModel.SearchTerm.ToLower());
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
            SubFundBindingModel model = new SubFundBindingModel
            {
                EntityProperties = this.subFundsService.GetActiveSubFundWithDateById(entityId),
                CalculationDate = new SelectList(this.subfundsSelectListService.GetAllTbDomCalculationDate()),
                CesrClass = new SelectList(this.subfundsSelectListService.GetAllTbDomCesrClass()),
                CurrencyCode = new SelectList(this.subfundsSelectListService.GetAllTbDomCurrencyCode()),
                DerivMarket = new SelectList(this.subfundsSelectListService.GetAllTbDomDerivMarket()),
                DerivPurpose = new SelectList(this.subfundsSelectListService.GetAllTbDomDerivPurpose()),
                Frequency = new SelectList(this.subfundsSelectListService.GetAllTbDomFrequency()),
                GeographicalFocus = new SelectList(this.subfundsSelectListService.GetAllTbDomGeographicalFocus()),
                GlobalExposure = new SelectList(this.subfundsSelectListService.GetAllTbDomGlobalExposure()),
                PrincipalAssetClass = new SelectList(this.subfundsSelectListService.GetAllTbDomPrincipalAssetClass()),
                PrincipalInvestmentStrategy = new SelectList(this.subfundsSelectListService.GetAllTbDomPrincipalInvestmentStrategy()),
                SfCatBloomberg = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatBloomberg()),
                SfCatMorningStar = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatMorningStar()),
                SfCatSix = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatSix()),
                SfStatus = new SelectList(this.subfundsSelectListService.GetAllTbDomSFStatus()),
                TypeOfMarket = new SelectList(this.subfundsSelectListService.GetAllTbDomTypeOfMarket()),
                ValuationDate = new SelectList(this.subfundsSelectListService.GetAllTbDomValuationDate()),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditSubFund(SubFundBindingModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //    return View(model ?? new EditFundBindingModel());
            // }
            int entityId = int.Parse(model.EntityProperties[1][0]);
            string returnUrl = $"/SubFunds/ViewSubFundSC/{entityId}";

            var subFund = this.subFundsService.GetActiveSubFundById(entityId);

            if (this.HttpContext.Request.Form.ContainsKey("modify_button"))
            {
                for (int row = 1; row < subFund.Count; row++)
                {
                    for (int col = 0; col < subFund[row].Length; col++)
                    {
                        subFund[row][col] = model.EntityProperties[row][col];
                    }
                }

                return this.LocalRedirect(returnUrl);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult CreateSubFund()
        {
            SubFundBindingModel model = new SubFundBindingModel
            {
                EntityProperties = this.subFundsService.GetAllActiveSubFunds(),
                CalculationDate = new SelectList(this.subfundsSelectListService.GetAllTbDomCalculationDate()),
                CesrClass = new SelectList(this.subfundsSelectListService.GetAllTbDomCesrClass()),
                CurrencyCode = new SelectList(this.subfundsSelectListService.GetAllTbDomCurrencyCode()),
                DerivMarket = new SelectList(this.subfundsSelectListService.GetAllTbDomDerivMarket()),
                DerivPurpose = new SelectList(this.subfundsSelectListService.GetAllTbDomDerivPurpose()),
                Frequency = new SelectList(this.subfundsSelectListService.GetAllTbDomFrequency()),
                GeographicalFocus = new SelectList(this.subfundsSelectListService.GetAllTbDomGeographicalFocus()),
                GlobalExposure = new SelectList(this.subfundsSelectListService.GetAllTbDomGlobalExposure()),
                PrincipalAssetClass = new SelectList(this.subfundsSelectListService.GetAllTbDomPrincipalAssetClass()),
                PrincipalInvestmentStrategy = new SelectList(this.subfundsSelectListService.GetAllTbDomPrincipalInvestmentStrategy()),
                SfCatBloomberg = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatBloomberg()),
                SfCatMorningStar = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatMorningStar()),
                SfCatSix = new SelectList(this.subfundsSelectListService.GetAllTbDomSfCatSix()),
                SfStatus = new SelectList(this.subfundsSelectListService.GetAllTbDomSFStatus()),
                TypeOfMarket = new SelectList(this.subfundsSelectListService.GetAllTbDomTypeOfMarket()),
                ValuationDate = new SelectList(this.subfundsSelectListService.GetAllTbDomValuationDate()),
            };

            return this.View(model);
        }
    }
}