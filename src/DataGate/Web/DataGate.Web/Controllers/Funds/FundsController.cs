namespace DataGate.Web.Controllers.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.AutoComplete;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewModel;
    using DataGate.Web.Utilities;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IFundsService fundsService;

        public FundsController(
            IFundsService fundsService)
        {
            this.fundsService = fundsService;
        }

        [HttpGet]
        [Route("f/all")]
        public IActionResult All()
        {
            var model = new EntitiesViewModel
            {
                IsActive = true,
                ChosenDate = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                EntitiesHeadersForColumnSelection = this.fundsService
                                                        .GetAllActive()
                                                        .Take(1)
                                                        .ToList(),
                Entities = this.fundsService.GetAllActive().ToList(),
            };

            return this.View(model);
        }

        public JsonResult AutoCompleteFundList(string selectTerm)
        {
            List<string[]> result = AutoCompleteService.GetEntityResult(selectTerm, this.fundsService);

            var modifiedData = result.Select(f => new
            {
                id = f[GlobalConstants.IndexEntityNameInSQLTable],
                text = f[GlobalConstants.IndexEntityNameInSQLTable],
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult All(EntitiesViewModel model)
        {
            ViewModelService.SetEntityViewModelProperties(model, this.fundsService);

            if (model.Entities.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
            this.ModelState.Clear();
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        [HttpPost]
        public IActionResult GenerateExcelReport(EntitiesViewModel model)
        {
            if (model.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.ExtractTableAsExcel(model.Entities, typeName, GlobalConstants.FundsControllerName);
            }
            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        [HttpPost]
        public IActionResult GeneratePdfReport(EntitiesViewModel model)
        {
            if (model.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.ExtractTableAsPdf(model.Entities, chosenDate, typeName, GlobalConstants.FundsControllerName);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }
    }
}
