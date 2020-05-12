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
                Date = chosenDate,
                Headers = headers.ToList(),
                HeadersSelection = headers.ToList(),
                Values = values,
            };

            return this.PartialView("SubEntities/_Overview", model);
        }

        [HttpPost]
        [ActionName("Reset")]
        public IActionResult ResetSubFunds([Bind("Id", "Date")] EntitiesViewModel model)
        {
            return this.RedirectToRoute(GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateSubFunds(EntitiesViewModel model)
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
