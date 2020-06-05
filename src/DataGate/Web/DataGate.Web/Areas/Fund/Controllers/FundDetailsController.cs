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
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IEntityDetailsService service;
        private readonly IFundService fundService;

        public FundDetailsController(
            IEntityDetailsService service,
            IFundService fundService)
        {
            this.service = service;
            this.fundService = fundService;
        }

        [ActionName("Details")]
        [Route("f/{id}/{date}")]
        public async Task<IActionResult> ByIdAndDate(int id, string date)
        {
            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = FunctionDictionary.SqlFunctionByIdFund,
                SqlFunctionDistinctDocuments = FunctionDictionary.SqlFunctionDistinctDocumentsFund,
                SqlFunctionDistinctAgreements = FunctionDictionary.SqlFunctionDistinctAgreementsFund,
            };

            var viewModel = await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, this.fundService, dto);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([Bind("Command,Date,Id")] SpecificEntityViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { viewModel.Id, viewModel.Date });
        }
    }
}
