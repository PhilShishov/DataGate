namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.ShareClasses;

    public class ShareClassesController : Controller
    {
        private readonly IShareClassesService _shareClassesService;
        private readonly IShareClassesSelectListService _shareClassesSelectListService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ShareClassesController(
            IShareClassesService shareClassesService,
            IShareClassesSelectListService shareClassesSelectListService,
            IHostingEnvironment hostingEnvironment)
        {
            this._shareClassesService = shareClassesService;
            this._shareClassesSelectListService = shareClassesSelectListService;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveEntitiesViewModel
            {
                ActiveEntities = this._shareClassesService.GetAllActiveShareClasses()
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(ActiveEntitiesViewModel model)
        {
            ModelState.Clear();
            model.ActiveEntities = this._shareClassesService.GetAllActiveShareClasses();

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.ActiveEntities = this._shareClassesService.GetAllActiveShareClasses(model.ChosenDate);
                }
            }

            else if (model.Command.Equals("Filter"))
            {
                if (model.SearchString == null)
                {
                    return this.View(model);
                }

                model.ActiveEntities = new List<string[]>();

                var tableHeaders = this._shareClassesService.GetAllActiveShareClasses().Take(1).ToList();
                var tableFundsWithoutHeaders = this._shareClassesService.GetAllActiveShareClasses().Skip(1).ToList();

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

        [HttpGet("ShareClasses/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            ActiveEntitiesViewModel viewModel = new ActiveEntitiesViewModel
            {
                EntityId = entityId,
                ActiveEntities = this._shareClassesService.GetActiveShareClassById(entityId)
            };

            return this.View(viewModel);
        }

        [HttpPost("ShareClasses/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(ActiveEntitiesViewModel viewModel)
        {
            viewModel.ActiveEntities = this._shareClassesService.GetActiveShareClassById(viewModel.EntityId);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveEntities = this._shareClassesService.GetActiveShareClassById(viewModel.ChosenDate, viewModel.EntityId);
                }
            }

            if (viewModel.ActiveEntities != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpGet("ShareClasses/EditShareClass/{EntityId}")]
        public IActionResult EditShareClass(int entityId)
        {
            EditShareClassBindingModel model = new EditShareClassBindingModel
            {
                EntityProperties = this._shareClassesService.GetActiveShareClassWithDateById(entityId),
                InvestorType = new SelectList(this._shareClassesSelectListService.GetAllTbDomInvestorType()),
                CurrencyCode = new SelectList(this._shareClassesSelectListService.GetAllTbDomCurrencyCode()),
                ShareStatus = new SelectList(this._shareClassesSelectListService.GetAllTbDomShareStatus()),
                ShareType = new SelectList(this._shareClassesSelectListService.GetAllTbDomShareType()),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditShareClass(EditShareClassBindingModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model ?? new EditFundBindingModel());
            //}

            int entityId = int.Parse(model.EntityProperties[1][0]);
            string returnUrl = $"/ShareClasses/ViewEntitySE/{entityId}";

            var shareClass = this._shareClassesService.GetActiveShareClassById(entityId);

            if (HttpContext.Request.Form.ContainsKey("modify_button"))
            {
                for (int row = 1; row < shareClass.Count; row++)
                {
                    for (int col = 0; col < shareClass[row].Length; col++)
                    {
                        shareClass[row][col] = model.EntityProperties[row][col];
                    }
                }

                return LocalRedirect(returnUrl);
            }

            return this.LocalRedirect(returnUrl);


            //[HttpGet]
            //public IActionResult NewSubFund()
            //{
            //    EditShareClassBindingModel model = new EditShareClassBindingModel
            //    {
            //        EntityProperties = this._shareClassesService.GetAllActiveSubFunds(),
            //        CalculationDate = new SelectList(this._shareClassesSelectListService.GetAllTbDomCalculationDate()),
            //        CesrClass = new SelectList(this._shareClassesSelectListService.GetAllTbDomCesrClass()),
            //        CurrencyCode = new SelectList(this._shareClassesSelectListService.GetAllTbDomCurrencyCode()),
            //        DerivMarket = new SelectList(this._shareClassesSelectListService.GetAllTbDomDerivMarket()),
            //        DerivPurpose = new SelectList(this._shareClassesSelectListService.GetAllTbDomDerivPurpose()),
            //        Frequency = new SelectList(this._shareClassesSelectListService.GetAllTbDomFrequency()),
            //        GeographicalFocus = new SelectList(this._shareClassesSelectListService.GetAllTbDomGeographicalFocus()),
            //        GlobalExposure = new SelectList(this._shareClassesSelectListService.GetAllTbDomGlobalExposure()),
            //        PrincipalAssetClass = new SelectList(this._shareClassesSelectListService.GetAllTbDomPrincipalAssetClass()),
            //        PrincipalInvestmentStrategy = new SelectList(this._shareClassesSelectListService.GetAllTbDomPrincipalInvestmentStrategy()),
            //        SfCatBloomberg = new SelectList(this._shareClassesSelectListService.GetAllTbDomSfCatBloomberg()),
            //        SfCatMorningStar = new SelectList(this._shareClassesSelectListService.GetAllTbDomSfCatMorningStar()),
            //        SfCatSix = new SelectList(this._shareClassesSelectListService.GetAllTbDomSfCatSix()),
            //        SfStatus = new SelectList(this._shareClassesSelectListService.GetAllTbDomSFStatus()),
            //        TypeOfMarket = new SelectList(this._shareClassesSelectListService.GetAllTbDomTypeOfMarket()),
            //        ValuationDate = new SelectList(this._shareClassesSelectListService.GetAllTbDomValuationDate())
            //    };

            //    return this.View(model);
            //}
        }
    }
}