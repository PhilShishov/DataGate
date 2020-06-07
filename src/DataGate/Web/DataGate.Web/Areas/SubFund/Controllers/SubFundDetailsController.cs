namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.SubFundAreaName)]
    [Authorize]
    public class SubFundDetailsController : BaseController
    {
        private readonly IEntityDetailsService service;
        private readonly ISubFundService subFundService;

        public SubFundDetailsController(
                                    IEntityDetailsService service,
                                    ISubFundService subFundService)
        {
            this.service = service;
            this.subFundService = subFundService;
        }

        [ActionName("Details")]
        [Route("sf/{id}/{date}")]
        public async Task<IActionResult> ByIdAndDate(int id, string date)
        {
            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = FunctionDictionary.SqlFunctionByIdSubFund,
                SqlFunctionDistinctDocuments = FunctionDictionary.SqlFunctionDistinctDocumentsSubFund,
                SqlFunctionDistinctAgreements = FunctionDictionary.SqlFunctionDistinctAgreementsSubFund,
                SqlFunctionContainer = FunctionDictionary.SqlFunctionContainerFund,
            };

            var viewModel = await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, this.subFundService, dto);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([Bind("Command,Date,Id")] SpecificEntityViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.RedirectToRoute(
                   GlobalConstants.SubFundDetailsRouteName,
                   new { viewModel.Id, viewModel.Date });
            }

            return this.ShowErrorAlertify(
               ErrorMessages.UnsuccessfulUpdate,
               GlobalConstants.SubFundDetailsRouteName,
               new { viewModel.Id, viewModel.Date });
        }
    }
}
