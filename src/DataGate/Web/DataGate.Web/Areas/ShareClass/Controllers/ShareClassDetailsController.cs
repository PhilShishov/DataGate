// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.ShareClasses.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Services.Data.Recent;

    [Area(EndpointsConstants.ShareClassArea)]
    [Authorize]
    public class ShareClassDetailsController : BaseController
    {
        private readonly IRecentService recentService;
        private readonly IEntityDetailsService service;
        private readonly IShareClassService shareClassService;
        private readonly SharedLocalizationService sharedLocalizer;

        public ShareClassDetailsController(
            IRecentService recentService,
            IEntityDetailsService service,
            IShareClassService shareClassService,
            SharedLocalizationService sharedLocalizer)
        {
            this.recentService = recentService;
            this.service = service;
            this.shareClassService = shareClassService;
            this.sharedLocalizer = sharedLocalizer;
        }

        [ActionName("Details")]
        [Route("sc/{id}/{date}")]
        public async Task<IActionResult> ByIdAndDate(int id, string date)
        {
            //await this.shareClassService.DoesExist(id);

            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = SqlFunctionDictionary.ByIdShareClass,
                SqlFunctionDistinctDocuments = SqlFunctionDictionary.DistinctDocumentsShareClass,
                SqlFunctionDistinctAgreements = SqlFunctionDictionary.DistinctAgreementsShareClass,
                SqlFunctionContainer = SqlFunctionDictionary.ContainerSubFund,
            };

            var viewModel = await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, dto);

            await this.recentService.Save(this.User, this.Request.Path);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([Bind("Command,Date,Id")] SpecificEntityViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.RedirectToRoute(
                           EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea,
                           new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(
                  this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                  EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea,
                  new { viewModel.Id, viewModel.Date });
        }
    }
}
