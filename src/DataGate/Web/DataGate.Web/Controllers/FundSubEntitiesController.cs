namespace DataGate.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using DataGate.Services.Data.FundSubFunds.Contracts;
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

            this.ModelState.Clear();
            return this.View(viewModel);
        }

        //public JsonResult AutoCompleteSubFundList(string selectTerm, int entityId)
        //{
        //    var entitiesToSearch = this.fundsService
        //        .GetFund_SubFunds(null, entityId)
        //        .Skip(1)
        //        .ToList();

        //    if (selectTerm != null)
        //    {
        //        entitiesToSearch = entitiesToSearch.Where(sf => sf[3]
        //                                             .ToLower()
        //                                             .Contains(selectTerm
        //                                             .ToLower()))
        //                                           .ToList();
        //    }

        //    var modifiedData = entitiesToSearch.Select(sf => new
        //    {
        //        id = sf[3],
        //        text = sf[3],
        //    });

        //    return this.Json(modifiedData);
        //}

        private void SetModelValuesForSpecificView(SpecificEntityViewModel model)
        {
            model.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var date = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
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
