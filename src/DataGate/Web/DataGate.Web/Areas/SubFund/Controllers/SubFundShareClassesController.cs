// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Recent;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)]
    [Authorize]
    public class SubFundShareClassesController : BaseController
    {
        private readonly IRecentService recentService;
        private readonly IEntityService service;
        private readonly ISubFundService subFundService;
        private readonly SharedLocalizationService sharedLocalizer;

        public SubFundShareClassesController(
            IRecentService recentService,
            IEntityService service,
            ISubFundService subFundService,
            SharedLocalizationService sharedLocalizer)
        {
            this.recentService = recentService;
            this.service = service;
            this.subFundService = subFundService;
            this.sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        [Route("loadShareClasses")]
        public async Task<IActionResult> LoadedShareClasses(int id, string date, string container)
        {
            var dto = new EntitySubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetLoadedGet<EntitySubEntitiesViewModel>(this.service, this.subFundService, dto, SqlFunctionDictionary.SubFundShareClasses);

            return this.PartialView("SubEntities/_ViewLoadedTable", viewModel);
        }

        [HttpGet]
        [Route("sf/{id}/sc")]
        public async Task<IActionResult> ShareClasses(int id, string date, string container)
        {
            var dto = new SubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetGet<SubEntitiesViewModel>(this.service, this.subFundService, dto, SqlFunctionDictionary.SubFundShareClasses);

            await this.recentService.Save(this.User, this.Request.Path);
            return this.View(viewModel);
        }

        [HttpPost]
        [Route("sf/{id}/sc")]
        public async Task<IActionResult> ShareClasses([Bind("Id,Command,Container,Date,Values,Headers,PreSelectedColumns,SelectedColumns")]
                                                   SubEntitiesViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.RedirectToRoute(
                    EndpointsConstants.SubFundShareClassesRouteName,
                    new { viewModel.Id, viewModel.Date, viewModel.Container });
            }

            await SubEntitiesVMSetup.SetPost(viewModel, this.service, SqlFunctionDictionary.SubFundShareClasses);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                return this.View(viewModel);
            }

            this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate));
            return this.View(viewModel);
        }
    }
}
