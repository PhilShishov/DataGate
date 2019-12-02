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
    using System.Globalization;
    using System;

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
            var model = new EntitiesViewModel
            {
                Entities = this.shareClassesService.GetAllActiveShareClasses(),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            this.ModelState.Clear();
            model.Entities = this.shareClassesService.GetAllActiveShareClasses();

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.Entities = this.shareClassesService.GetAllActiveShareClasses(chosenDate);
                }
            }
            else if (model.Command.Equals("Search"))
            {
                if (model.SearchTerm == null)
                {
                    return this.View(model);
                }

                model.Entities = new List<string[]>();

                var tableHeaders = this.shareClassesService.GetAllActiveShareClasses().Take(1).ToList();
                var tableFundsWithoutHeaders = this.shareClassesService.GetAllActiveShareClasses().Skip(1).ToList();

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

        [HttpGet("ShareClasses/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(int entityId)
        {
            EntitiesViewModel viewModel = new EntitiesViewModel
            {
                EntityId = entityId,
                Entities = this.shareClassesService.GetActiveShareClassById(entityId),
                BaseEntityName = this.shareClassesService.GetShareClass_SubFundContainer(entityId)[1][1],
            };

            return this.View(viewModel);
        }

        [HttpPost("ShareClasses/ViewEntitySE/{EntityId}")]
        public IActionResult ViewEntitySE(EntitiesViewModel viewModel)
        {
            viewModel.Entities = this.shareClassesService.GetActiveShareClassById(viewModel.EntityId);

            var chosenDate = DateTime.ParseExact(viewModel.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (viewModel.Command.Equals("Update Table"))
            {
                if (viewModel.ChosenDate != null)
                {
                    viewModel.Entities = this.shareClassesService.GetActiveShareClassById(chosenDate, viewModel.EntityId);
                }
            }

            if (viewModel.Entities != null)
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
            if (!ModelState.IsValid)
            {
                return View(model ?? new ShareClassBindingModel());
            }
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