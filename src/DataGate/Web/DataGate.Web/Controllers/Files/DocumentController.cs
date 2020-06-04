namespace DataGate.Web.Controllers.Files
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.Helpers;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.ViewModels.Documents;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentService service;
        private readonly IEntitiesDocumentService entitiesDocumentService;

        public DocumentController(
                        IDocumentService service,
                        IEntitiesDocumentService entitiesDocumentService)
        {
            this.service = service;
            this.entitiesDocumentService = entitiesDocumentService;
        }

        [Route("loadDocUpload")]
        public IActionResult Document(LoadDocumentDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadDocumentInputModel>(dto);

            if (model.AreaName == GlobalConstants.FundAreaName)
            {
                model.DocumentTypes = this.service.GetDocumentsFileTypes(QueryDictionary.FundFileType);
            }
            else if (model.AreaName == GlobalConstants.SubFundAreaName)
            {
                model.DocumentTypes = this.service.GetDocumentsFileTypes(QueryDictionary.SubFundFileType);
            }
            else if (model.AreaName == GlobalConstants.ShareClassAreaName)
            {
                model.DocumentTypes = this.service.GetDocumentsFileTypes(QueryDictionary.ShareClassFileType);
            }

            return this.PartialView("Upload/_UploadDocument", model);
        }

        [Route("loadAgrUpload")]
        public async Task<IActionResult> Agreement(LoadAgreementDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadAgreementInputModel>(dto);
            model.AgreementsStatus = await this.service.GetAgreementStatus().ToListAsync();
            model.Companies = await this.service.GetCompanies().ToListAsync();

            if (model.AreaName == GlobalConstants.FundAreaName)
            {
                model.AgreementsFileTypes = await this.service.GetAgreementsFileTypes(QueryDictionary.FundFileType).ToListAsync();
            }
            else if (model.AreaName == GlobalConstants.SubFundAreaName)
            {
                model.AgreementsFileTypes = await this.service.GetAgreementsFileTypes(QueryDictionary.SubFundFileType).ToListAsync();
            }
            else if (model.AreaName == GlobalConstants.ShareClassAreaName)
            {
                model.AgreementsFileTypes = await this.service.GetAgreementsFileTypes(QueryDictionary.ShareClassFileType).ToListAsync();
            }

            return this.PartialView("Upload/_UploadAgreement", model);
        }

        [Route("loadAllDoc")]
        public IActionResult GetAllDocuments(int id, string areaName)
        {
            var model = new DocumentOverviewViewModel { AreaName = areaName };

            if (areaName == GlobalConstants.FundAreaName)
            {
                model.Documents = this.entitiesDocumentService.GetAllDocuments<DocumentViewModel>(QueryDictionary.SqlFunctionDocumentsFund, id);
            }
            else if (areaName == GlobalConstants.SubFundAreaName)
            {
                model.Documents = this.entitiesDocumentService.GetAllDocuments<DocumentViewModel>(QueryDictionary.SqlFunctionDocumentsSubFund, id);
            }
            else if (areaName == GlobalConstants.ShareClassAreaName)
            {
                model.Documents = this.entitiesDocumentService.GetAllDocuments<DocumentViewModel>(QueryDictionary.SqlFunctionDocumentsShareClass, id);
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
                model.Agreements = this.entitiesDocumentService.GetAllAgreements<AgreementViewModel>(QueryDictionary.SqlFunctionAgreementsFund, id, dateParsed);
            }
            else if (areaName == GlobalConstants.SubFundAreaName)
            {
                model.Agreements = this.entitiesDocumentService.GetAllAgreements<AgreementViewModel>(QueryDictionary.SqlFunctionAgreementsSubFund, id, dateParsed);
            }
            else if (areaName == GlobalConstants.ShareClassAreaName)
            {
                model.Agreements = this.entitiesDocumentService.GetAllAgreements<AgreementViewModel>(QueryDictionary.SqlFunctionAgreementsShareClass, id, dateParsed);
            }

            return this.PartialView("SpecificEntity/_AllAgreements", model);
        }
    }
}
