namespace DataGate.Web.Controllers
{
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SubEntitiesController : BaseController
    {
        private readonly IFundSubEntitiesService subFundsService;

        public SubEntitiesController(IFundSubEntitiesService subFundsService)
        {
            this.subFundsService = subFundsService;
        }

        [Route("loadSubEntities")]
        public IActionResult GetAll(int id, string chosenDate, string controllerName)
        {
            EntitiesViewModel model = new EntitiesViewModel();
            var date = DateTimeParser.WebFormat(chosenDate);

            if (controllerName == GlobalConstants.FundDetailsControllerName)
            {
                var headers = this.subFundsService.GetHeaders(id, date).ToList();
                model.Headers = headers;
                model.HeadersSelection = headers;
                model.Values = this.subFundsService.GetSubEntities(id, date, null, 1).ToList();
            }

            return this.PartialView("SubEntities/_Overview", model);
        }
    }
}
