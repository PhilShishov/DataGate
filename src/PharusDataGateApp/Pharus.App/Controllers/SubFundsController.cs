namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;

    using Pharus.App.Utilities;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.App.Models.BindingModels.SubFunds;

    public class SubFundsController : Controller
    {
        private readonly ISubFundsService subFundsService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SubFundsController(ISubFundsService subFundsService,
            IHostingEnvironment hostingEnvironment)
        {
            this.subFundsService = subFundsService;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new ActiveEntitiesViewModel
            {
                ActiveEntities = this.subFundsService.GetAllActiveSubFunds()
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(ActiveEntitiesViewModel model)
        {
            ModelState.Clear();
            model.ActiveEntities = this.subFundsService.GetAllActiveSubFunds();

            if (model.Command.Equals("Update Table"))
            {
                if (model.ChosenDate != null)
                {
                    model.ActiveEntities = this.subFundsService.GetAllActiveSubFunds(model.ChosenDate);
                }
            }

            else if (model.Command.Equals("Filter"))
            {
                if (model.SearchString == null)
                {
                    return this.View(model);
                }

                model.ActiveEntities = new List<string[]>();

                var tableHeaders = this.subFundsService.GetAllActiveSubFunds().Take(1).ToList();
                var tableFundsWithoutHeaders = this.subFundsService.GetAllActiveSubFunds().Skip(1).ToList();

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

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.ActiveEntities, typeName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractExcelSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;

            if (HttpContext.Request.Form.ContainsKey("extract_Excel"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsExcel(model.AESubEntities, typeName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfEntities(ActiveEntitiesViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.ActiveEntities, model.ChosenDate, _hostingEnvironment, typeName);
            }

            return fileStreamResult;
        }

        [HttpPost]
        public FileStreamResult ExtractPdfSubEntities(SpecificEntityViewModel model)
        {
            FileStreamResult fileStreamResult = null;

            string typeName = model.GetType().Name;

            if (HttpContext.Request.Form.ContainsKey("extract_Pdf"))
            {
                fileStreamResult = ExtractTable.ExtractTableAsPdf(model.AESubEntities, model.ChosenDate, _hostingEnvironment, typeName);
            }

            return fileStreamResult;
        }

        [HttpGet("SubFunds/ViewSubFundSC/{EntityId}")]
        public IActionResult ViewSubFundSC(int entityId)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                EntityId = entityId,
                ActiveEntity = this.subFundsService.GetActiveSubFundById(entityId),
                AESubEntities = this.subFundsService.GetSubFundShareClasses(entityId)
            };

            return this.View(viewModel);
        }

        [HttpPost("SubFunds/ViewSubFundSC/{EntityId}")]
        public IActionResult ViewSubFundSC(SpecificEntityViewModel viewModel)
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
                if (viewModel.SearchString == null)
                {
                    return this.View(viewModel);
                }

                viewModel.AESubEntities = new List<string[]>();

                var tableHeaders = this.subFundsService.GetSubFundShareClasses(viewModel.EntityId).Take(1).ToList();
                var tableFundsWithoutHeaders = this.subFundsService.GetSubFundShareClasses(viewModel.EntityId).Skip(1).ToList();

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
                EntityProperties = this.subFundsService.GetActiveSubFundWithDateById(entityId)
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

            var subFund = this.subFundsService.GetActiveSubFundById(entityId);

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
    }
}