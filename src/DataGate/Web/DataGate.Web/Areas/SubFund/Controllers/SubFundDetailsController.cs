namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.SubFunds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.SubFundAreaName)]
    [Authorize]
    public class SubFundDetailsController : BaseController
    {
        private readonly ISubFundDetailsService service;

        public SubFundDetailsController(ISubFundDetailsService service)
        {
            this.service = service;
        }

        [ActionName("Details")]
        [Route("sf/{id}/{date}")]
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
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.SubFundDetailsRouteName, new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.SubFundDetailsRouteName, new { viewModel.Id, viewModel.Date });
        }
    }
}
