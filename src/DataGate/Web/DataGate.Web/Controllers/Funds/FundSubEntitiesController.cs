namespace DataGate.Web.Controllers.Funds
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Web.Utilities;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FundSubEntitiesController : BaseController
    {
        private readonly IFundSubFundsService fundsService;

        public FundSubEntitiesController(IFundSubFundsService fundSubFundsService)
        {
            this.fundsService = fundSubFundsService;
        }

        [HttpGet]
        [Route("f/{EntityId}/{ChosenDate}")]
        public IActionResult ByIdAndDate(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            this.SetModelValuesForSpecificView(viewModel);

            this.ModelState.Clear();
            return this.View(viewModel);
        }

        public JsonResult AutoCompleteSubFundList(string selectTerm, int entityId)
        {
            var entitiesToSearch = this.fundsService
                .GetFund_SubFunds(null, entityId)
                .Skip(1)
                .ToList();

            if (selectTerm != null)
            {
                entitiesToSearch = entitiesToSearch
                    .Where(sf => sf[GlobalConstants.IndexEntityNameInSQLTable]
                        .ToLower()
                        .Contains(selectTerm
                        .ToLower()))
                    .ToList();
            }

            var modifiedData = entitiesToSearch.Select(sf => new
            {
                id = sf[GlobalConstants.IndexEntityNameInSQLTable],
                text = sf[GlobalConstants.IndexEntityNameInSQLTable],
            });

            return this.Json(modifiedData);
        }

        [HttpPost]
        public IActionResult ByIdAndDate(SpecificEntityViewModel model)
        {
            this.SetModelValuesForSpecificView(model);

            if (model.Command == "Update Table")
            {
                this.TempData[GlobalConstants.ParentInfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.EntityId, model.ChosenDate });
            }

            if (model.Command == "Reset")
            {
                model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
                return this.View(model);
            }

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);

            if (model.SelectTerm == null)
            {
                if (isInSelectionMode)
                {
                    this.CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
                }
                else if (!isInSelectionMode)
                {
                    model.EntitySubEntities = this.fundsService.GetFund_SubFunds(chosenDate, model.EntityId).ToList();
                }

                return this.View(model);
            }

            if (isInSelectionMode)
            {
                this.CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
            }
            else if (!isInSelectionMode)
            {
                model.EntitySubEntities = this.fundsService
                    .GetFund_SubFunds(chosenDate, model.EntityId)
                    .ToList();
            }

            if (model.SelectTerm != null)
            {
                model.EntitySubEntities = CreateTableView.AddTableToView(model.EntitySubEntities, model.SelectTerm.ToLower());
            }

            if (model.Entity != null && model.EntitySubEntities.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
                return this.View(model);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
            this.ModelState.Clear();
            return this.View();
        }

        [HttpPost]
        public IActionResult GenerateExcelReport(SpecificEntityViewModel model)
        {
            int count = model.EntitySubEntities.Count;
            if (count > GlobalConstants.RowNumberOfHeadersInTable && model.EntityId != 0)
            {
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.ExtractTableAsExcel(model.EntitySubEntities, typeName, GlobalConstants.FundsControllerName);
            }

            if (model.EntityId != 0 && model.ChosenDate != null)
            {
                this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.EntityId, model.ChosenDate });
            }

            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        [HttpPost]
        public IActionResult GeneratePdfReport(SpecificEntityViewModel model)
        {
            int count = model.EntitySubEntities.Count;
            if (count > GlobalConstants.RowNumberOfHeadersInTable && model.EntityId != 0)
            {
                // TODO prepare query for less than 16 columns
                //if (model.EntitySubEntities[GlobalConstants.IndexEntityHeadersInSqlTable].Length > GlobalConstants.NumberOfAllowedColumnsInPdfView)
                //{
                //    model.EntitySubEntities = this.fundsService.PrepareFund_SubFundsForPDFExtract(date).ToList();
                //}
                var date = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
                string typeName = model.GetType().Name;
                return GenerateFileTemplate.ExtractTableAsPdf(model.EntitySubEntities, date, typeName, GlobalConstants.FundsControllerName);
            }

            if (model.EntityId != 0 && model.ChosenDate != null)
            {
                this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
                return this.RedirectToAction(GlobalConstants.ByIdAndDateActionName, new { model.EntityId, model.ChosenDate });
            }

            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime chosenDate)
        {
            model.EntitySubEntities = this.fundsService
                .GetFund_SubFundsWithSelectedViewAndDate(
                                                model.PreSelectedColumns,
                                                model.SelectedColumns,
                                                chosenDate,
                                                model.EntityId)
                .ToList();
        }

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {

            //private void ThrowEntityNotFoundExceptionIfFundDoesNotExist(int fundId)
            //{
            //    if (!this.Exists(fundId))
            //    {
            //        throw new EntityNotFoundException(nameof(TbHistoryFund));
            //    }
            //}

            //private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);


            var date = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
            int entityId = model.EntityId;

            model.Entity = this.fundsService.GetFundWithDateById(date, entityId).ToList();
            model.EntityDistinctDocuments = this.fundsService.
                GetDistinctFundDocuments(date, entityId).ToList();
            model.EntityDistinctAgreements = this.fundsService.GetDistinctFundAgreements(date, entityId).ToList();

            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(date, entityId).ToList();
            model.EntitiesHeadersForColumnSelection = this.fundsService
                                                                .GetFund_SubFunds(date, entityId)
                                                                .Take(1)
                                                                .ToList();
            model.EntityTimeline = this.fundsService.GetFundTimeline(entityId).ToList();
            model.EntityDocuments = this.fundsService.GetAllFundDocuments(entityId).ToList();
            model.EntityAgreements = this.fundsService.GetAllFundAgreements(date, entityId).ToList();

            model.StartConnection = DateTime.ParseExact(model.Entity.ToList()[1][0], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);

            if (model.EndConnection != null)
            {
                model.EndConnection = DateTime.ParseExact(model.Entity.ToList()[1][1], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
            }

            //this.ViewData["ProspectusFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }
    }
}
