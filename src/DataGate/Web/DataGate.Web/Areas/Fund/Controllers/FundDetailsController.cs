namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(EndpointsConstants.FundArea)]
    [Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IEntityDetailsService service;
        private readonly IFundService fundService;
        private readonly SharedLocalizationService sharedLocalizer;

        public FundDetailsController(
            IEntityDetailsService service,
            IFundService fundService,
            SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.fundService = fundService;
            this.sharedLocalizer = sharedLocalizer;
        }

        [ActionName("Details")]
        [Route("f/{id}/{date}")]
        public async Task<IActionResult> ByIdAndDate(int id, string date)
        {
            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = SqlFunctionDictionary.ByIdFund,
                SqlFunctionActiveSE = SqlFunctionDictionary.FundActiveSubFunds,
                SqlFunctionDistinctDocuments = SqlFunctionDictionary.DistinctDocumentsFund,
                SqlFunctionDistinctAgreements = SqlFunctionDictionary.DistinctAgreementsFund,
            };

            var viewModel = await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, this.fundService, dto);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([Bind("Command,Date,Id")] SpecificEntityViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.RedirectToRoute(
                           EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                           new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(
                  this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                  EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                  new { viewModel.Id, viewModel.Date });
        }
    }
}
