namespace DataGate.Web.Controllers.Files
{
    using DataGate.Common;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Web.ViewModels.Documents;
    using DataGate.Web.ViewModels.Files;

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
        public IActionResult LoadDocument(UploadDocumentViewModel model)
        {
            if (model.ControllerName == GlobalConstants.FundSubEntitiesControllerName)
            {
                this.ViewData["DocumentFileTypes"] = this.fundSelectService.GetDocumentsFileTypes();
            }

            return this.PartialView("SpecificEntity/_UploadDocument", model);
        }

        [Route("loadSelectAgr")]
        public IActionResult LoadAgreement(UploadAgreementViewModel model)
        {
            if (model.ControllerName == GlobalConstants.FundSubEntitiesControllerName)
            {
                this.ViewData["AgreementsFileTypes"] = this.fundSelectService.GetAgreementsFileTypes();
                this.ViewData["AgreementsStatus"] = this.fundSelectService.GetAgreementStatus();
                this.ViewData["Companies"] = this.fundSelectService.GetCompanies();
            }

            return this.PartialView("SpecificEntity/_UploadAgreement", model);
        }

        //[Route("loadAllDoc")]
        //public IActionResult GetAllDocuments(AllDocViewModel model)
        //{
        //    model = this.fundSelectService.GetAllDocuments<AllDocViewModel>(model.Id);

        //    return this.PartialView("SpecificEntity/_AllDocuments", model);
        //}

        //[Route("loadAllAgr")]
        //public IActionResult GetAllAgreements(SpecificEntityViewModel model)
        //{
        //    model.Agreements = this.fundSelectService.GetAllAgreements<AllAgrViewModel>(model.Id, model.Date);

        //    return this.PartialView("SpecificEntity/_AllDocuments", model);
        //}
    }
}
