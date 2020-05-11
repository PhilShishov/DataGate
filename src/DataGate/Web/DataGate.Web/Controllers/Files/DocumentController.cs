namespace DataGate.Web.Controllers.Files
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Documents;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IFundDocumentService fundService;

        public DocumentController(
                        IFundDocumentService fundService)
        {
            this.fundService = fundService;
        }

        [Route("loadDocUpload")]
        public IActionResult LoadDocumentUpload(string controllerName)
        {
            if (controllerName == GlobalConstants.FundDetailsControllerName)
            {
                this.ViewData["DocumentFileTypes"] = this.fundService.GetDocumentsFileTypes();
            }

            return this.PartialView("SpecificEntity/_UploadDocument");
        }

        [Route("loadAgrUpload")]
        public async Task<IActionResult> LoadAgreementUpload(string controllerName)
        {
            if (controllerName == GlobalConstants.FundDetailsControllerName)
            {
                this.ViewData["AgreementsFileTypes"] = await this.fundService.GetAgreementsFileTypes();
                this.ViewData["AgreementsStatus"] = await this.fundService.GetAgreementStatus();
                this.ViewData["Companies"] = await this.fundService.GetCompanies();
            }

            return this.PartialView("SpecificEntity/_UploadAgreement");
        }

        [Route("loadAllDoc")]
        public IActionResult GetAllDocuments(int id, string controllerName)
        {
            IEnumerable<AllDocViewModel> model = null;

            if (controllerName == GlobalConstants.FundDetailsControllerName)
            {
                model = this.fundService.GetAllDocuments<AllDocViewModel>(id);
            }

            return this.PartialView("SpecificEntity/_AllDocuments", model);
        }

        [Route("loadAllAgr")]
        public IActionResult GetAllAgreements(int id, string chosenDate, string controllerName)
        {
            IEnumerable<AllAgrViewModel> model = null;
            var date = DateTimeParser.WebFormat(chosenDate);

            if (controllerName == GlobalConstants.FundDetailsControllerName)
            {
                model = this.fundService.GetAllAgreements<AllAgrViewModel>(id, date);
            }

            return this.PartialView("SpecificEntity/_AllAgreements", model);
        }
    }
}
