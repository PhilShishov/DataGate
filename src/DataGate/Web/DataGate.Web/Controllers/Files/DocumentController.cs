namespace DataGate.Web.Controllers.Files
{
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Web.ViewModels.Files;
    using Microsoft.AspNetCore.Mvc;

    public class DocumentController : Controller
    {
        private readonly IDocumentsSelectService fundSelectService;

        public DocumentController(IDocumentsSelectService fundSelectService)
        {
            this.fundSelectService = fundSelectService;
        }

        [Route("f/loadDoc")]
        public IActionResult LoadFundDocument(UploadDocumentViewModel model)
        {
            this.ViewData["DocumentFileTypes"] = this.fundSelectService.GetDocumentsFileTypes();
            return this.PartialView("SpecificEntity/_UploadDocument", model);
        }

        [Route("f/loadAgr")]
        public IActionResult LoadFundAgreement(UploadAgreementViewModel model)
        {
            this.ViewData["AgreementsFileTypes"] = this.fundSelectService.GetAgreementsFileTypes();
            this.ViewData["AgreementsStatus"] = this.fundSelectService.GetAgreementStatus();
            this.ViewData["Companies"] = this.fundSelectService.GetCompanies();
            return this.PartialView("SpecificEntity/_UploadAgreement", model);
        }
    }
}
