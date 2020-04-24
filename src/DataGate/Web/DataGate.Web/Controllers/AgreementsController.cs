namespace DataGate.Web.Controllers
{
    using System;
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc;

    using DataGate.Services.Agreements.Contracts;
    using DataGate.Web.Models.ViewModels.Agreements;

    public class AgreementsController : Controller
    {
        private readonly IAgreementsService agreementsService;

        public AgreementsController(
            IAgreementsService agreementsService)
        {
            this.agreementsService = agreementsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new AgreementsViewModel
            {
                ChosenDate = DateTime.Today.ToString("yyyy-MM-dd"),
            };

            var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            model.FundAgreements = this.agreementsService.GetAgreementsForAllFunds(chosenDate);
            model.SubFundAgreements = this.agreementsService.GetAgreementsForAllSubFunds(chosenDate);
            model.ShareClassAgreements = this.agreementsService.GetAgreementsForAllShareClasses(chosenDate);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(AgreementsViewModel model)
        {
            if (model.ChosenDate != null)
            {
                var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                model.FundAgreements = this.agreementsService.GetAgreementsForAllFunds(chosenDate);
                model.SubFundAgreements = this.agreementsService.GetAgreementsForAllSubFunds(chosenDate);
                model.ShareClassAgreements = this.agreementsService.GetAgreementsForAllShareClasses(chosenDate);
            }

            if (model.FundAgreements != null)
            {
                return this.View(model);
            }

            return this.RedirectToPage("/Agreements/All");
        }
    }
}