namespace DataGate.Web.Controllers.Funds
{
    using System;
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
            var model = new EntitiesOverviewViewModel
            {
                IsActive = true,
                Date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                HeadersSelection = this.service.GetAllActive(null, 1),
                Headers = this.service.GetAllActive(null, 1).ToList(),
                Values = this.service.GetAllActive(null, null, 1).ToList(),
            };

            return this.View(model);
        }

        public JsonResult AutoCompleteFundList(string selectTerm)
        {
            IEnumerable<string[]> result = AutoCompleteService.GetResult(selectTerm, this.service);

            var modifiedData = result.Select(f => new
            {
                id = f[GlobalConstants.IndexEntityNameInSQLTable],
                text = f[GlobalConstants.IndexEntityNameInSQLTable],
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesOverviewViewModel model)
        {
            EntityViewModelSetup.SetModel(model, this.service);

            if (model.Values != null)
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
