namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundDetailsController : BaseController
    {
        private readonly IFundDetailsService service;

        public FundDetailsController(IFundDetailsService fundSubFundsService)
        {
            this.service = fundSubFundsService;
        }

        [ActionName("Details")]
        [Route("f/{id}/{date}")]
        public IActionResult ByIdAndDate(int id, string date)
        {
            var viewModel = SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service);
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
