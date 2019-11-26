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
        private readonly IShareClassesService shareClassesService;
        private readonly IShareClassesSelectListService shareClassesSelectListService;
        private readonly IHostingEnvironment hostingEnvironment;

        public ShareClassesController(
            IShareClassesService shareClassesService,
            IShareClassesSelectListService shareClassesSelectListService,
            IHostingEnvironment hostingEnvironment)
        {
            this.shareClassesService = shareClassesService;
            this.shareClassesSelectListService = shareClassesSelectListService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveEntitiesViewModel
            {
                ActiveEntities = this.shareClassesService.GetAllActiveShareClasses(),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(ActiveEntitiesViewModel model)
        {
            this.ModelState.Clear();
            model.ActiveEntities = this.shareClassesService.GetAllActiveShareClasses();

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.ActiveEntities = this.shareClassesService.GetAllActiveShareClasses(model.ChosenDate);
                }
            }
            else if (model.Command.Equals("Search"))
            {
                if (model.SearchTerm == null)
                {
                    return this.View(model);
                }

                model.ActiveEntities = new List<string[]>();

                var tableHeaders = this.shareClassesService.GetAllActiveShareClasses().Take(1).ToList();
                var tableFundsWithoutHeaders = this.shareClassesService.GetAllActiveShareClasses().Skip(1).ToList();

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

        [HttpGet("ShareClasses/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            ActiveEntitiesViewModel viewModel = new ActiveEntitiesViewModel
            {
                EntityId = entityId,
                ActiveEntities = this.shareClassesService.GetActiveShareClassById(entityId),
            };

            return this.View(viewModel);
        }

        [HttpPost("ShareClasses/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(ActiveEntitiesViewModel viewModel)
        {
            viewModel.ActiveEntities = this.shareClassesService.GetActiveShareClassById(viewModel.EntityId);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.ActiveEntities = this.shareClassesService.GetActiveShareClassById(viewModel.ChosenDate, viewModel.EntityId);
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
            ShareClassBindingModel model = new ShareClassBindingModel
            {
                EntityProperties = this.shareClassesService.GetActiveShareClassWithDateById(entityId),
                InvestorType = new SelectList(this.shareClassesSelectListService.GetAllTbDomInvestorType()),
                CurrencyCode = new SelectList(this.shareClassesSelectListService.GetAllTbDomCurrencyCode()),
                CountryIssue = new SelectList(this.shareClassesSelectListService.GetAllTbDomCountry()),
                CountryRisk = new SelectList(this.shareClassesSelectListService.GetAllTbDomCountry()),
                ShareStatus = new SelectList(this.shareClassesSelectListService.GetAllTbDomShareStatus()),
                ShareType = new SelectList(this.shareClassesSelectListService.GetAllTbDomShareType()),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditShareClass(ShareClassBindingModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //    return View(model ?? new EditFundBindingModel());
            // }
            int entityId = int.Parse(model.EntityProperties[1][0]);
            string returnUrl = $"/ShareClasses/ViewEntitySE/{entityId}";

            var shareClass = this.shareClassesService.GetActiveShareClassById(entityId);

            if (this.HttpContext.Request.Form.ContainsKey("modify_button"))
            {
                for (int row = 1; row < shareClass.Count; row++)
                {
                    for (int col = 0; col < shareClass[row].Length; col++)
                    {
                        shareClass[row][col] = model.EntityProperties[row][col];
                    }
                }

                return this.LocalRedirect(returnUrl);
            }

            return this.LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult CreateShareClass()
        {
            ShareClassBindingModel model = new ShareClassBindingModel
            {
                EntityProperties = this.shareClassesService.GetAllActiveShareClasses(),
                InvestorType = new SelectList(this.shareClassesSelectListService.GetAllTbDomInvestorType()),
                CurrencyCode = new SelectList(this.shareClassesSelectListService.GetAllTbDomCurrencyCode()),
                CountryIssue = new SelectList(this.shareClassesSelectListService.GetAllTbDomCountry()),
                CountryRisk = new SelectList(this.shareClassesSelectListService.GetAllTbDomCountry()),
                ShareStatus = new SelectList(this.shareClassesSelectListService.GetAllTbDomShareStatus()),
                ShareType = new SelectList(this.shareClassesSelectListService.GetAllTbDomShareType()),
            };

            return this.View(model);
        }
    }
}