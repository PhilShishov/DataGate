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

            int fileType = this.GetTargetFileType(model.AreaName);
            model.DocumentTypes = this.service.GetDocumentsFileTypes(fileType);

            return this.PartialView("Upload/_UploadDocument", model);
        }

        [Route("loadAgrUpload")]
        public async Task<IActionResult> Agreement(LoadAgreementDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadAgreementInputModel>(dto);

            model.AgreementsStatus = await this.service.GetAgreementStatus().ToListAsync();
            model.Companies = await this.service.GetCompanies().ToListAsync();

            int fileType = this.GetTargetFileType(model.AreaName);
            model.AgreementsFileTypes = await this.service.GetAgreementsFileTypes(fileType).ToListAsync();

            return this.PartialView("Upload/_UploadAgreement", model);
        }

        [Route("loadDistinct")]
        public IActionResult GetDistinct(int id, string date, string areaName)
        {
            var model = new DistinctOverviewViewModel { AreaName = areaName };
            var dateParsed = DateTimeParser.FromWebFormat(date);

            string functionDoc = StringSwapper.GetResult(areaName,
                                             FunctionDictionary.SqlFunctionDistinctDocumentsFund,
                                             FunctionDictionary.SqlFunctionDistinctDocumentsSubFund,
                                             FunctionDictionary.SqlFunctionDistinctDocumentsShareClass);

            string functionAgr = StringSwapper.GetResult(areaName,
                                             FunctionDictionary.SqlFunctionDistinctAgreementsFund,
                                             FunctionDictionary.SqlFunctionDistinctAgreementsSubFund,
                                             FunctionDictionary.SqlFunctionDistinctAgreementsShareClass);

            model.Documents = this.entitiesDocumentService.GetDistinctDocuments<DistinctDocViewModel>(functionDoc, id, dateParsed);
            model.Agreements = this.entitiesDocumentService.GetDistinctAgreements<DistinctAgrViewModel>(functionAgr, id, dateParsed);

            return this.PartialView("SpecificEntity/_DistinctDocuments", model);
        }

        [Route("loadAllDoc")]
        public IActionResult GetAllDocuments(int id, string areaName)
        {
            var model = new DocumentOverviewViewModel { AreaName = areaName };

            string function = StringSwapper.GetResult(areaName,
                                                FunctionDictionary.SqlFunctionDocumentsFund,
                                                FunctionDictionary.SqlFunctionDocumentsSubFund,
                                                FunctionDictionary.SqlFunctionDocumentsShareClass);

            model.Documents = this.entitiesDocumentService.GetDocuments<DocumentViewModel>(function, id);

            return this.PartialView("SpecificEntity/_AllDocuments", model);
        }

        [Route("loadAllAgr")]
        public IActionResult GetAllAgreements(int id, string date, string areaName)
        {
            var model = new AgreementOverviewViewModel { AreaName = areaName };
            var dateParsed = DateTimeParser.FromWebFormat(date);

            string function = StringSwapper.GetResult(areaName,
                                             FunctionDictionary.SqlFunctionAgreementsFund,
                                             FunctionDictionary.SqlFunctionAgreementsSubFund,
                                             FunctionDictionary.SqlFunctionAgreementsShareClass);

            model.Agreements = this.entitiesDocumentService.GetAgreements<AgreementViewModel>(function, id, dateParsed);

            return this.PartialView("SpecificEntity/_AllAgreements", model);
        }

        private int GetTargetFileType(string area)
        {
            int fileType = 0;

            if (area == GlobalConstants.FundAreaName)
            {
                fileType = FunctionDictionary.FundFileType;
            }
            else if (area == GlobalConstants.SubFundAreaName)
            {
                fileType = FunctionDictionary.SubFundFileType;
            }
            else if (area == GlobalConstants.ShareClassAreaName)
            {
                fileType = FunctionDictionary.ShareClassFileType;
            }

            return fileType;
        }
    }
}
