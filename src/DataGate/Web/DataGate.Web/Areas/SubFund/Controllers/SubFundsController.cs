// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Columns;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Layouts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)]
    [Authorize]
    public class SubFundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly ILayoutService layoutService;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly IUserRepository<UserSubFundColumn> repository;

        public SubFundsController(
            IEntityService service,
            ILayoutService layoutService,
            SharedLocalizationService sharedLocalizer,
            IUserRepository<UserSubFundColumn> repository)
        {
            this.service = service;
            this.layoutService = layoutService;
            this.sharedLocalizer = sharedLocalizer;
            this.repository = repository;
        }

        [HttpGet]
        [Route("subfunds")]
        public async Task<IActionResult> All()
        {
            var user = await this.layoutService.UserWithLayouts(this.User);
            var userColumns = this.layoutService.GetLayout<UserSubFundColumn>(this.repository, user.Id);

            var viewModel = await EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveSubFund, userColumns);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,Command,PreSelectedColumns,SelectedColumns")] 
                                              EntitiesViewModel model)
        {
            var user = await this.layoutService.UserWithLayouts(this.User);
            var userColumns = this.layoutService.GetLayout<UserSubFundColumn>(this.repository, user.Id);

            if (userColumns.Count() > 0)
            {
                model.SelectedColumns = userColumns;
            }

            await EntitiesVMSetup.SetPost(model, this.service, 
                                          SqlFunctionDictionary.AllSubFund, 
                                          SqlFunctionDictionary.AllActiveSubFund);

            if (model.Values != null && model.Values.Count > 0)
            {
                return this.View(model);
            }

            return this.ShowError(
                  this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                  EndpointsConstants.ActionAll,
                  EndpointsConstants.DisplaySub + EndpointsConstants.FundsController);
        }
    }
}
