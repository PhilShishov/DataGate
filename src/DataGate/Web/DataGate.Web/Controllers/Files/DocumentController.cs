namespace DataGate.Web.Controllers.Files
{
    using System.Collections.Generic;

    using DataGate.Common;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Documents;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentsSelectService fundSelectService;

        public DocumentController(
                        IDocumentsSelectService fundSelectService)
        {
            this.fundSelectService = fundSelectService;
        }

        [Route("loadSelectDoc")]
        public IActionResult LoadDocument(string controllerName)
        {
            if (controllerName == GlobalConstants.FundSubEntitiesControllerName)
            {
                this.ViewData["DocumentFileTypes"] = this.fundSelectService.GetDocumentsFileTypes();
            }

            return this.PartialView("SpecificEntity/_UploadDocument");
        }

        [Route("loadSelectAgr")]
        public IActionResult LoadAgreement(string controllerName)
        {
            if (controllerName == GlobalConstants.FundSubEntitiesControllerName)
            {
                this.ViewData["AgreementsFileTypes"] = this.fundSelectService.GetAgreementsFileTypes();
                this.ViewData["AgreementsStatus"] = this.fundSelectService.GetAgreementStatus();
                this.ViewData["Companies"] = this.fundSelectService.GetCompanies();
            }

            return this.PartialView("SpecificEntity/_UploadAgreement");
        }

        [Route("loadAllDoc")]
        public IActionResult GetAllDocuments(int id, string controllerName)
        {
            IEnumerable<AllDocViewModel> model = null;

            if (controllerName == GlobalConstants.FundSubEntitiesControllerName)
            {
                model = this.fundSelectService.GetAllDocuments<AllDocViewModel>(id);
            }

            return this.PartialView("SpecificEntity/_AllDocuments", model);
        }

        [Route("loadAllAgr")]
        public IActionResult GetAllAgreements(int id, string chosenDate, string controllerName)
        {
            IEnumerable<AllAgrViewModel> model = null;
            var date = DateTimeParser.WebFormat(chosenDate);

            if (controllerName == GlobalConstants.FundSubEntitiesControllerName)
            {
                model = this.fundSelectService.GetAllAgreements<AllAgrViewModel>(id, date);
            }

            return this.PartialView("SpecificEntity/_AllAgreements", model);
        }
    }
}
