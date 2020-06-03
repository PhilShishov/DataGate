namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.SubFunds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.SubFundAreaName)]
    [Authorize]
    public class SubFundShareClassesController : BaseController
    {
        private readonly ISubFundShareClassesService service;

        public SubFundShareClassesController(ISubFundShareClassesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("loadShareClasses")]
        public async Task<IActionResult> LoadedShareClasses(int id, string date, string container)
        {
            var viewModel = await SubEntitiesVMSetup.SetLoadedGet<EntitySubEntitiesViewModel>(id, date, container, this.service);

            return this.PartialView("SubEntities/_ViewLoadedTable", viewModel);
        }

        [HttpGet]
        [Route("sf/{id}/sf")]
        public async Task<IActionResult> ShareClasses(int id, string date, string container)
        {
            var viewModel = await SubEntitiesVMSetup.SetGet<SubEntitiesViewModel>(id, date, container, this.service);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("sf/{id}/sf")]
        public async Task<IActionResult> ShareClasses([Bind("Id, Command, Container, Date,Values,Headers,PreSelectedColumns,SelectedColumns,SelectTerm")]
                                                   SubEntitiesViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandResetTable)
            {
                return this.RedirectToAction("ShareClasses", new { viewModel.Id, viewModel.Date, viewModel.Container });
            }

            await SubEntitiesVMSetup.SetPost(viewModel, this.service);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.UnsuccessfulUpdate;
            return this.View(viewModel);
        }
    }
}
