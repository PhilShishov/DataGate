namespace DataGate.Web.Areas.ShareClasses.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.ShareClasses.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.ShareClassAreaName)]
    [Authorize]
    public class ShareClassDetailsController : BaseController
    {
        private readonly IShareClassDetailsService service;

        public ShareClassDetailsController(IShareClassDetailsService service)
        {
            this.service = service;
        }

        [ActionName("Details")]
        [Route("sc/{id}/{date}")]
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
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.ShareClassDetailsRouteName, new { viewModel.Id, viewModel.Date });
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.ShareClassDetailsRouteName, new { viewModel.Id, viewModel.Date });
        }
    }
}
