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

    [Area(GlobalConstants.FundsAreaName)]
    [Authorize]
    public class FundSubFundsController : BaseController
    {
        private readonly IFundSubFundsService subFundsService;

        public FundSubFundsController(IFundSubFundsService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [Route("loadSubFunds")]
        public async Task<IActionResult> GetAllAsync(int id, string chosenDate)
        {
            var model = await SubEntitiesVMSetup.SetGet<SubEntitiesViewModel>(id, chosenDate, this.subFundsService);

            return this.PartialView("SubEntities/_Overview", model);
        }

        [HttpPost]
        [ActionName("Reset")]
        public IActionResult ResetSubFunds([Bind("Id", "Date")] SubEntitiesViewModel model)
        {
            return this.RedirectToRoute(GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }

        [HttpGet]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateSubFunds(SubEntitiesViewModel model)
        {
            await SubEntitiesVMSetup.SetPost(model, this.subFundsService);

            if (model.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.PartialView("SubEntities/_Overview", model);
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }
    }
}
