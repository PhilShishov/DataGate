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
            var date = DateTimeParser.WebFormat(chosenDate);
            var headers = await this.subFundsService.GetSubEntities(id, date).FirstOrDefaultAsync();
            var values = await this.subFundsService.GetSubEntities(id, date).ToListAsync();

            EntitiesViewModel model = new EntitiesViewModel()
            {
                Id = id,
                Headers = headers.ToList(),
                HeadersSelection = headers.ToList(),
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
