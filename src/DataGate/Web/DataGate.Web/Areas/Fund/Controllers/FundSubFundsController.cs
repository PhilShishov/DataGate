namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundSubFundsController : BaseController
    {
        private readonly IFundSubFundsService service;

        public FundSubFundsController(IFundSubFundsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("loadSubFunds")]
        public async Task<IActionResult> LoadedSubFunds(int id, string date, string container)
        {
            var viewModel = await SubEntitiesVMSetup.SetLoadedGet<EntitySubEntitiesViewModel>(id, date, container, this.service);

            return this.PartialView("SubEntities/_ViewLoadedTable", viewModel);
        }

        [HttpGet]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds(int id, string date, string container)
        {
            var viewModel = await SubEntitiesVMSetup.SetGet<SubEntitiesViewModel>(id, date, container, this.service);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds([Bind("Id, Command, Container, Date,Values,Headers,PreSelectedColumns,SelectedColumns,SelectTerm")]
                                                   SubEntitiesViewModel viewModel)
        {
            if (viewModel.Command == GlobalConstants.CommandUpdateTable)
            {
                return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.FundSubFundsRouteName, new { viewModel.Id, viewModel.Date, viewModel.Container });
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
