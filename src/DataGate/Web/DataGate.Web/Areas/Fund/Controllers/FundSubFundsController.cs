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
        private readonly IFundDetailsService fundService;
        private readonly IFundSubFundsService subFundsService;

        public FundSubFundsController(IFundSubFundsService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [HttpGet]
        [Route("loadSubFunds")]
        public async Task<IActionResult> LoadedSubFunds(int id, string date, string container)
        {
            var model = await SubEntitiesVMSetup.SetLoadedGet<EntitySubEntitiesViewModel>(id, date, container, this.subFundsService);

            return this.PartialView("SubEntities/_ViewLoadedTable", model);
        }

        [HttpGet]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds(int id, string date, string container)
        {
            var model = await SubEntitiesVMSetup.SetGet<SubEntitiesViewModel>(id, date, container, this.subFundsService);

            return this.View(model);
        }

        [HttpPost]
        [Route("f/{id}/sf")]
        public async Task<IActionResult> SubFunds([Bind("Id, Command, Container, Date,Values,Headers,PreSelectedColumns,SelectedColumns,SelectTerm")]
                                                   SubEntitiesViewModel model)
        {
            if (model.Command == GlobalConstants.CommandResetTable)
            {
                return this.RedirectToAction("SubFunds", new { model.Id, model.Date, model.Container });
            }

            await SubEntitiesVMSetup.SetPost(model, this.subFundsService);

            if (model.Values != null && model.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorKey] = ErrorMessages.UnsuccessfulUpdate;
            return this.View(model);
        }
    }
}
