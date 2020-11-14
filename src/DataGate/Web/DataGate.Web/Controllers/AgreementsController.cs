namespace DataGate.Web.Controllers
{
    using System;
    using System.Text.RegularExpressions;

    using DataGate.Common;
    using DataGate.Services.Data.Agreements.Contracts;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Agreements;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgreementsController : BaseController
    {
        private readonly IAgreementsService service;
        private readonly SharedLocalizationService sharedLocalizer;

        public AgreementsController(
            IAgreementsService service,
            SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        [Route("allagreements")]
        public IActionResult Overview()
        {
            return this.View();
        }

        [HttpGet]
        [Route("agreements/{type}")]
        public IActionResult All(string type)
        {
            string function = StringSwapper.ByArea(type,
                                                  SqlFunctionDictionary.AllAgreementsFunds,
                                                  SqlFunctionDictionary.AllAgreementsSubFunds,
                                                  SqlFunctionDictionary.AllAgreementsShareClasses);

            var today = DateTime.Today;
            var agreements = this.service.GetAll<AgreementViewModel>(function, today);

            var viewModel = new AgreementOverviewViewModel()
            {
                Date = today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                Agreements = agreements,
                SelectedType = Regex.Replace(type, "(\\B[A-Z])", " $1"),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult All(AgreementOverviewViewModel model)
        {
            if (model.Date != null)
            {
                string function = StringSwapper.ByArea(model.SelectedType,
                                                  SqlFunctionDictionary.AllAgreementsFunds,
                                                  SqlFunctionDictionary.AllAgreementsSubFunds,
                                                  SqlFunctionDictionary.AllAgreementsShareClasses);

                var parsedDate = DateTimeParser.FromWebFormat(model.Date);

                model.Agreements = this.service.GetAll<AgreementViewModel>(function, parsedDate);
            }

            if (model.Agreements != null)
            {
                return this.View(model);
            }

            this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate));
            return this.View(model);
        }
    }
}
