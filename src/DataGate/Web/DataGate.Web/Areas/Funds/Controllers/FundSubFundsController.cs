namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Linq;

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
        private readonly IFundSubEntitiesService subFundsService;

        public FundSubFundsController(IFundSubEntitiesService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [Route("loadSubFunds")]
        public IActionResult GetAll(int id, string chosenDate, string controllerName)
        {
            var date = DateTimeParser.WebFormat(chosenDate);
            var headers = this.subFundsService.GetHeaders(id, date).ToList();
            var values = this.subFundsService.GetSubEntities(id, date, null, 1).ToList();

            EntitiesViewModel model = new EntitiesViewModel()
            {
                Id = id,
                Headers = headers,
                HeadersSelection = headers,
                Values = values,
            };

            return this.PartialView("SubEntities/_Overview", model);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateSubFunds(EntitiesViewModel model)
        {
            if (model.Command == GlobalConstants.CommandResetTable)
            {
                model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
                return this.PartialView("SubEntities/_Overview");
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
