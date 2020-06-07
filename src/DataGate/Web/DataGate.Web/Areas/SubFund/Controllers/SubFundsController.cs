﻿namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(GlobalConstants.SubFundAreaName)]
    [Authorize]
    public class SubFundsController : BaseController
    {
        private readonly IEntityService service;

        public SubFundsController(IEntityService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("subfunds")]
        public async Task<IActionResult> All()
        {
            var viewModel = await EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service, FunctionDictionary.SqlFunctionAllActiveSubFund);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] EntitiesViewModel viewModel)
        {
            await EntitiesVMSetup.SetPost(viewModel, this.service, FunctionDictionary.SqlFunctionAllSubFund, FunctionDictionary.SqlFunctionAllActiveSubFund);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                return this.View(viewModel);
            }

            return this.ShowErrorAlertify(
                ErrorMessages.TableIsEmpty,
                GlobalConstants.AllActionName,
                GlobalConstants.SubFundsControllerName);
        }
    }
}
