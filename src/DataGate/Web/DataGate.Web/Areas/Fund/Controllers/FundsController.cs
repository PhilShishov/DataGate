namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Collections.Generic;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IFundService service;

        public FundsController(IFundService fundsService)
        {
            this.service = fundsService;
        }

        [HttpGet]
        [Route("f/all")]
        public IActionResult All()
        {
            var viewModel = EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] EntitiesViewModel viewModel)
        {
            EntitiesVMSetup.SetPost(viewModel, this.service);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            return this.ShowError(ErrorMessages.TableIsEmpty, GlobalConstants.AllActionName, GlobalConstants.FundsControllerName);
        }

        [HttpGet]
        [Route("loadFundExtract")]
        public IActionResult GetExtract(List<string> headers)
        {
            var model = new ExtractViewModel
            {
                //Headers = headers,
                //Names = ,
                //Values = ,
            };
            return this.PartialView("Extract/_Extract", model);
        }
    }
}
