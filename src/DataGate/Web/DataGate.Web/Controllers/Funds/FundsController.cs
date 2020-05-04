namespace DataGate.Web.Controllers.Funds
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.AutoComplete;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    //[Authorize]
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
            var model = this.service.GetEntitiesOverview<EntitiesOverviewViewModel>();

            return this.View(model);
        }

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

            if (model != null)
            {
                this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
            this.ModelState.Clear();
            return this.Redirect(GlobalConstants.FundAllUrl);
        }
    }
}
