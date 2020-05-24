namespace DataGate.Web.Controllers.Files
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.InputModels.Files;
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
        public IActionResult Document(LoadDocumentDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadDocumentInputModel>(dto);

            if (model.AreaName == GlobalConstants.FundAreaName)
            {
                model.DocumentTypes = this.fundService.GetDocumentsFileTypes();
            }

            return this.PartialView("Upload/_UploadDocument", model);
        }

        [Route("loadAgrUpload")]
        public async Task<IActionResult> Agreement(LoadAgreementDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadAgreementInputModel>(dto);
            if (model.AreaName == GlobalConstants.FundAreaName)
            {
                model.AgreementsFileTypes = await this.fundService.GetAgreementsFileTypes().ToListAsync();
                model.AgreementsStatus = await this.fundService.GetAgreementStatus().ToListAsync();
                model.Companies = await this.fundService.GetCompanies().ToListAsync();
            }

            return this.PartialView("Upload/_UploadAgreement", model);
        }

        [Route("loadAllDoc")]
        public IActionResult GetAllDocuments(int id, string areaName)
        {
            var model = new DocumentOverviewViewModel { AreaName = areaName };

            if (areaName == GlobalConstants.FundAreaName)
            {
                model.Documents = this.fundService.GetAllDocuments<DocumentViewModel>(id);
            }

            return this.PartialView("SpecificEntity/_AllDocuments", model);
        }

        [Route("loadAllAgr")]
        public IActionResult GetAllAgreements(int id, string date, string areaName)
        {
            var model = new AgreementOverviewViewModel { AreaName = areaName };
            var dateParsed = DateTimeParser.WebFormat(date);

            if (areaName == GlobalConstants.FundAreaName)
            {
                model.Agreements = this.fundService.GetAllAgreements<AgreementViewModel>(id, dateParsed);
            }

            return this.PartialView("SpecificEntity/_AllAgreements", model);
        }
    }
}
