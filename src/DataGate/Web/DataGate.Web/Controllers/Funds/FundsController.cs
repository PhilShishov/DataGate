namespace DataGate.Web.Controllers.Funds
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data;
    using DataGate.Services.Data.Funds.Contracts;
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
            var result = this.fundsService
                .GetAll(null)
                .Skip(1)
                .ToList();

            if (selectTerm != null)
            {
                result = result
                    .Where(f => f[GlobalConstants.IndexEntityNameInSQLTable]
                        .ToLower()
                        .Contains(selectTerm.ToLower()))
                    .ToList();
            }

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
            this.NewMethod(model);

            if (model.Entities.Count > GlobalConstants.NumberOfHeadersInTable)
            {
                this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModelIsEmpty;
            this.ModelState.Clear();
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        private void NewMethod(EntitiesViewModel model)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.EntitiesHeadersForColumnSelection = this.fundsService
                                                            .GetAllActive()
                                                            .Take(1)
                                                            .ToList();

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null && model.SelectedColumns.ToList().Count > 0)
            {
                isInSelectionMode = true;
            }

            DateTime? chosenDate = null;

            if (model.ChosenDate != null)
            {
                chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            }

            if (isInSelectionMode)
            {
                if (model.IsActive)
                {
                    this.CallActiveEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!model.IsActive)
                {
                    this.CallAllEntitiesWithSelectedColumns(model, chosenDate);
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Entities = this.fundsService.GetAllActive(chosenDate).ToList();
                }
                else if (!model.IsActive)
                {
                    model.Entities = this.fundsService.GetAll(chosenDate).ToList();
                }
            }

            if (model.SelectTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities.ToList(), model.SelectTerm.ToLower());
            }
        }

        [HttpPost]
        public IActionResult GenerateExcelReport(EntitiesViewModel model)
        {
            int count = model.Entities.Count;
            if (count > GlobalConstants.NumberOfHeadersInTable)
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
            int count = model.Entities.Count;
            if (count > GlobalConstants.NumberOfHeadersInTable)
            {
                var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.ExtractTableAsPdf(model.Entities, chosenDate, typeName, GlobalConstants.FundsControllerName);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        private void CallAllEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.fundsService
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate)
                .ToList();
        }

        private void CallActiveEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate)
        {
            model.Entities = this.fundsService
                .GetAllActiveWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate)
                .ToList();
        }
    }
}
