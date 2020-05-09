namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.FundsAreaName)]
    [Authorize]
    public class FundSubFundsController : BaseController
    {
        private readonly IFundSubEntitiesService subFundsService;

        public FundSubFundsController(IFundSubEntitiesService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateSubFunds(EntitiesViewModel model)
        {
            if (model.Command == GlobalConstants.CommandResetTable)
            {
                model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
                return this.View(model);
            }

            SubEntitiesVMSetup.SetPost(model, this.subFundsService);

            if (model.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(model);
            }

            return this.ShowError(ErrorMessages.UnsuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }
    }
}
