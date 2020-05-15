namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Services.DateTime;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundSubFundsController : BaseController
    {
        private readonly IFundSubFundsService subFundsService;

        public FundSubFundsController(IFundSubFundsService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [HttpGet]
        [Route("loadSubFunds")]
        public async Task<IActionResult> SubEntities(int id, string date)
        {
            var model = await SubEntitiesVMSetup.SetGet<SubEntitiesViewModel>(id, date, this.subFundsService);

            return this.PartialView("SubEntities", model);
        }

        [HttpPost]
        [Route("loadSubFunds")]
        public async Task<IActionResult> SubEntities(SubEntitiesViewModel model)
        {
            if (model.Command == GlobalConstants.CommandResetTable)
            {
                return this.RedirectToRoute(GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
            }

            await SubEntitiesVMSetup.SetPost(model, this.subFundsService);

            if (model.Values != null)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.PartialView(model);
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }
    }
}
