// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers.Users
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Columns;
    using DataGate.Services.Data.Layouts;
    using DataGate.Web.InputModels.Layouts;
    using DataGate.Web.Resources;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class LayoutController : BaseController
    {
        private readonly ILayoutService layoutService;
        private readonly IUserRepository<UserFundColumn> userFRepository;
        private readonly IUserRepository<UserSubFundColumn> userSFRepository;
        private readonly IUserRepository<UserShareClassColumn> userSCRepository;
        private readonly SharedLocalizationService sharedLocalizer;

        public LayoutController(
            ILayoutService layoutService,
            IUserRepository<UserFundColumn> userFRepository,
            IUserRepository<UserSubFundColumn> userSFRepository,
            IUserRepository<UserShareClassColumn> userSCRepository,
            SharedLocalizationService sharedLocalizer)
        {
            this.layoutService = layoutService;
            this.userFRepository = userFRepository;
            this.userSFRepository = userSFRepository;
            this.userSCRepository = userSCRepository;
            this.sharedLocalizer = sharedLocalizer;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Save(SaveLayoutInputModel input)
        {
            if (input.SelectedColumns != null)
            {
                await this.SaveLayout(input);

                return this.Json(new { success = true, controller = input.ControllerName, area = input.AreaOrigin });
            }

            return this.Json(new { success = false });
        }

        public IActionResult OnSaveLayoutSuccess(string controllerOrigin, string areaOrigin)
        {
            return this.ShowInfo(
                   this.sharedLocalizer.GetHtmlString(InfoMessages.LayoutSaved),
                   EndpointsConstants.ActionAll,
                   controllerOrigin,
                   new { area = areaOrigin });
        }

        public async Task<IActionResult> Default(string controllerName)
        {
            var area = await this.RestoreLayout(controllerName);

            return this.RedirectToAction(
                EndpointsConstants.ActionAll,
                controllerName,
                new { area = area });
        }

        private async Task<string> RestoreLayout(string controller)
        {
            string area = string.Empty;
            var user = await this.layoutService.UserWithLayouts(this.User);

            switch (controller)
            {
                case EndpointsConstants.FundsController:
                    area = EndpointsConstants.FundArea;
                    await this.userFRepository.RestoreLayout(user.UserFundColumns);
                    break;
                case EndpointsConstants.DisplaySub + EndpointsConstants.FundsController:
                    area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea;
                    await this.userSFRepository.RestoreLayout(user.UserSubFundColumns);
                    break;
                case EndpointsConstants.ShareClassesController:
                    area = EndpointsConstants.ShareClassArea;
                    await this.userSCRepository.RestoreLayout(user.UserShareClassColumns);
                    break;
            }

            return area;
        }

        private async Task SaveLayout(SaveLayoutInputModel input)
        {
            var user = await this.layoutService.UserWithLayouts(this.User);

            switch (input.ControllerName)
            {
                case EndpointsConstants.FundsController:
                    var columnsToDbF = this.layoutService.ColumnsToDb<UserFundColumn>(input.SelectedColumns, user.Id);
                    await this.userFRepository.SaveLayout(user.UserFundColumns, columnsToDbF);
                    break;
                case EndpointsConstants.DisplaySub + EndpointsConstants.FundsController:
                    var columnsToDbSF = this.layoutService.ColumnsToDb<UserSubFundColumn>(input.SelectedColumns, user.Id);
                    await this.userSFRepository.SaveLayout(user.UserSubFundColumns, columnsToDbSF);
                    break;
                case EndpointsConstants.ShareClassesController:
                    var columnsToDbSC = this.layoutService.ColumnsToDb<UserShareClassColumn>(input.SelectedColumns, user.Id);
                    await this.userSCRepository.SaveLayout(user.UserShareClassColumns, columnsToDbSC);
                    break;
            }
        }

    }
}
