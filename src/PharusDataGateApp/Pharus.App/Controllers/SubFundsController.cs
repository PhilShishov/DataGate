namespace Pharus.App.Controllers
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using Pharus.Data;
    using Pharus.App.Utilities;
    using Pharus.Services.SubFunds.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.SubFunds;

    public class SubFundsController : Controller
    {
        private readonly Pharus_vFinale_Context context;
        private readonly ISubFundsService subFundsService;
        private readonly ISubFundsSelectListService subfundsSelectListService;
        private readonly IHostingEnvironment hostingEnvironment;

        public SubFundsController(
            Pharus_vFinale_Context context,
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
            var model = new EntitiesViewModel
            {
                Entities = this.subFundsService.GetAllActiveSubFunds(),
                IsActive = true,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            this.ModelState.Clear();
            model.Entities = this.subFundsService.GetAllActiveSubFunds();

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
                        model.Entities = this.subFundsService.GetAllActiveSubFunds(chosenDate);
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
                    .GetAllActiveSubFunds()
                    .Take(1)
                    .ToList();
                var tableFundsWithoutHeaders = this.subFundsService.GetAllActiveSubFunds().Skip(1).ToList();

                CreateTableView.AddHeadersToView(model.Entities, tableHeaders);

                CreateTableView.AddTableToView(model.Entities, tableFundsWithoutHeaders, model.SearchTerm.ToLower());
            }

            if (model.Entities != null)
            {
                return this.View(model);
            }

            return this.View();
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

        [HttpGet("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                Entity = this.subFundsService.GetActiveSubFundById(entityId),
                EntitySubEntities = this.subFundsService.GetSubFund_ShareClasses(entityId),
                BaseEntityName = this.subFundsService.GetSubFund_FundContainer(entityId)[1][1],
            };

            return this.View(viewModel);
        }

        [HttpPost("SubFunds/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(SpecificEntityViewModel viewModel)
        {
            viewModel.Entity = this.subFundsService.GetActiveSubFundById(viewModel.EntityId);
            viewModel.EntitySubEntities = this.subFundsService.GetSubFund_ShareClasses(viewModel.EntityId);

            var chosenDate = DateTime.ParseExact(viewModel.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.Entity = this.subFundsService.GetActiveSubFundById(chosenDate, viewModel.EntityId);
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