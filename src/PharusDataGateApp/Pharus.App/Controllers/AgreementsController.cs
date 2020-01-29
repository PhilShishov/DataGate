namespace Pharus.App.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Pharus.Services.Agreements.Contracts;
    using Pharus.App.Models.ViewModels.Agreements;

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

            var chosenDate = DateTime.Parse(model.ChosenDate);

            model.FundAgreements = this.agreementsService.GetAgreementsForAllFunds(chosenDate);
            model.SubFundAgreements = this.agreementsService.GetAgreementsForAllSubFunds(chosenDate);
            model.ShareClassAgreements = this.agreementsService.GetAgreementsForAllShareClasses(chosenDate);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All(AgreementsViewModel model)
        {
            if (model.FundAgreements != null)
            {
                return this.View(model);
            }

            return this.RedirectToPage("/Agreements/All");
        }
    }
}