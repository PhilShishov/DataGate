namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(EndpointsConstants.FundArea)]
    [Authorize]
    public class FundSubFundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly IFundService fundService;
        private readonly SharedLocalizationService sharedLocalizer;

        public FundSubFundsController(
            IEntityService service,
            IFundService fundService,
            SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.fundService = fundService;
            this.sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        [Route("loadSubFunds")]
        public async Task<IActionResult> LoadedSubFunds(int id, string date, string container)
        {
            var dto = new EntitySubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetLoadedGet<EntitySubEntitiesViewModel>(this.service, this.fundService, dto, SqlFunctionDictionary.FundSubFunds);

            return this.PartialView("SubEntities/_ViewLoadedTable", viewModel);
        }

        [HttpGet]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds(int id, string date, string container)
        {
            var dto = new SubEntitiesGetDto()
            {
                Id = id,
                Date = date,
                Container = container,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetGet<SubEntitiesViewModel>(this.service, this.fundService, dto, SqlFunctionDictionary.FundSubFunds);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds([Bind("Id, Command, Container, Date,Values,Headers," +
                                                        "PreSelectedColumns,SelectedColumns,SelectTerm")]
                                                   SubEntitiesViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.RedirectToRoute(
                   EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                   new { viewModel.Id, viewModel.Date, viewModel.Container });
            }

            await SubEntitiesVMSetup.SetPost(viewModel, this.service, SqlFunctionDictionary.FundSubFunds);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                return this.View(viewModel);
            }

            this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate));
            return this.View(viewModel);
        }
    }
}
