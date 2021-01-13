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
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)]
    [Authorize]
    public class SubFundDetailsController : BaseController
    {
        private readonly IRecentService recentService;
        private readonly IEntityDetailsService service;
        private readonly ISubFundService subFundService;
        private readonly SharedLocalizationService sharedLocalizer;

        public SubFundDetailsController(
            IRecentService recentService,
            IEntityDetailsService service,
            ISubFundService subFundService,
            SharedLocalizationService sharedLocalizer)
        {
            this.recentService = recentService;
            this.service = service;
            this.subFundService = subFundService;
            this.sharedLocalizer = sharedLocalizer;
        }

        [ActionName("Details")]
        [Route("sf/{id}/{date}")]
        public async Task<IActionResult> ByIdAndDate(int id, string date)
        {
            //await this.subFundService.DoesExist(id);

            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = SqlFunctionDictionary.ByIdSubFund,
                SqlFunctionActiveSE = SqlFunctionDictionary.SubFundActiveShareClasses,
                SqlFunctionDistinctDocuments = SqlFunctionDictionary.DistinctDocumentsSubFund,
                SqlFunctionDistinctAgreements = SqlFunctionDictionary.DistinctAgreementsSubFund,
                SqlFunctionContainer = SqlFunctionDictionary.ContainerFund,
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
                   EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                   new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(
                this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                new { viewModel.Id, viewModel.Date });
        }
    }
}
