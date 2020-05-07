namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.AutoComplete;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(GlobalConstants.FundsAreaName)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IFundsService service;

        public FundsController(IFundsService fundsService)
        {
            this.service = fundsService;
        }

        [HttpGet]
        [Route("f/all")]
        public IActionResult All()
        {
            var model = GetOverview.Entities<EntitiesOverviewViewModel>(this.service);

            return this.View(model);
        }

        [Route("api/autofunds")]
        public JsonResult AutoCompleteFundList(string selectTerm)
        {
            ISet<string> result = AutoCompleteService.GetResult(selectTerm, this.service);

            var modifiedData = result.Select(f => new
            {
                id = f,
                text = f,
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesOverviewViewModel model)
        {
            EntityViewModelSetup.SetModel(model, this.service);

            if (model.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfullyUpdatedTable;
                return this.View(model);
            }

            return this.ShowError(ErrorMessages.TableIsEmpty, "All", "Funds");
        }
    }
}
