// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.Funds.Controllers
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

    [Area(EndpointsConstants.FundArea)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly ILayoutService layoutService;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly IUserRepository<UserFundColumn> repository;

        public FundsController(
            IEntityService service,
            ILayoutService layoutService,
            SharedLocalizationService sharedLocalizer,
            IUserRepository<UserFundColumn> repository)
        {
            this.service = service;
            this.layoutService = layoutService;
            this.sharedLocalizer = sharedLocalizer;
            this.repository = repository;
        }

        [HttpGet]
        [Route("funds")]
        public async Task<IActionResult> All()
        {
            var user = await this.layoutService.UserWithLayouts(this.User);
            var userColumns = this.layoutService.GetLayout<UserFundColumn>(this.repository, user.Id);

            var model = await EntitiesVMSetup
                .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveFund, userColumns);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,Command,PreSelectedColumns,SelectedColumns")]
                                              EntitiesViewModel model)
        {
            var user = await this.layoutService.UserWithLayouts(this.User);
            var userColumns = this.layoutService.GetLayout<UserFundColumn>(this.repository, user.Id);

            if (userColumns.Count() > 0)
            {
                model.SelectedColumns = userColumns;
            }

            await EntitiesVMSetup.SetPost(model, this.service, SqlFunctionDictionary.AllFund, SqlFunctionDictionary.AllActiveFund);

            if (model.Values != null && model.Values.Count > 0)
            {
                return this.View(model);
            }

            return this.ShowError(
                   this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                   EndpointsConstants.ActionAll,
                   EndpointsConstants.FundsController);
        }
    }
}