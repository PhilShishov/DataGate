namespace DataGate.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.FundSubFunds.Contracts;
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
        public IActionResult ByIdAndDate(int entityId, string chosenDate)
        {
            SpecificEntityViewModel viewModel = new SpecificEntityViewModel
            {
                ChosenDate = chosenDate,
                EntityId = entityId,
            };

            this.SetModelValuesForSpecificView(viewModel);

            //this.HttpContext.Session.SetString("entityId", Convert.ToString(entityId));

            //this.ModelState.Clear();
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
        [Route("f/{EntityId}/{ChosenDate}")]
        public IActionResult ByIdAndDate(SpecificEntityViewModel model)
        {
            this.SetModelValuesForSpecificView(model);

            if (model.Command == "Reset")
            {
                model.SelectTerm = "Quick Select";
                return this.View(model);
            }

            bool isInSelectionMode = false;

            var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.DateTimeFormatDisplay, CultureInfo.InvariantCulture);

            if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
            {
                isInSelectionMode = true;
            }

            model.Entity = this.fundsService
                   .GetFundWithDateById(chosenDate, model.EntityId)
                   .ToList();

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

            if (model.Entity != null && model.EntitySubEntities != null)
            {
                return this.View(model);
            }

            this.ModelState.Clear();
            return this.View();
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
            model.ControllerName = this.ControllerContext.RouteData.Values[GlobalConstants.ControllerRouteDataValue].ToString();
            var date = DateTime.ParseExact(model.ChosenDate, GlobalConstants.DateTimeFormatDisplay, CultureInfo.InvariantCulture);
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

            model.StartConnection = DateTime.ParseExact(model.Entity.ToList()[1][0], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (model.EndConnection != null)
            {
                model.EndConnection = DateTime.ParseExact(model.Entity.ToList()[1][1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            //this.ViewData["ProspectusFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }
    }
}
