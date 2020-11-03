namespace DataGate.Web.Controllers.Files
{
    using DataGate.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.ViewModels.Documents;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentService service;
        private readonly IAgreementsRepository repository;
        private readonly IEntitiesDocumentService entitiesDocumentService;

        public DocumentController(
                        IDocumentService service,
                        IAgreementsRepository repository,
                        IEntitiesDocumentService entitiesDocumentService)
        {
            this.service = service;
            this.repository = repository;
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
        public IActionResult Agreement(LoadAgreementDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadAgreementInputModel>(dto);

            model.AgreementsStatus = this.repository.GetAllAgreementStatus();
            model.Companies = this.repository.GetAllCompanies();

            int fileType = this.GetTargetFileType(model.AreaName);
            model.AgreementsFileTypes = this.repository.GetAllAgreementsFileTypes(fileType);

            return this.PartialView("Upload/_UploadAgreement", model);
        }

        [Route("loadDistinct")]
        public IActionResult GetDistinct(int id, string date, string areaName)
        {
            var model = new DistinctOverviewViewModel { AreaName = areaName };
            var dateParsed = DateTimeParser.FromWebFormat(date);

            string functionDoc = StringSwapper.ByArea(areaName,
                                             SqlFunctionDictionary.DistinctDocumentsFund,
                                             SqlFunctionDictionary.DistinctDocumentsSubFund,
                                             SqlFunctionDictionary.DistinctDocumentsShareClass);

            string functionAgr = StringSwapper.ByArea(areaName,
                                             SqlFunctionDictionary.DistinctAgreementsFund,
                                             SqlFunctionDictionary.DistinctAgreementsSubFund,
                                             SqlFunctionDictionary.DistinctAgreementsShareClass);

            model.Documents = this.entitiesDocumentService.GetDistinctDocuments<DistinctDocViewModel>(functionDoc, id, dateParsed);
            model.Agreements = this.entitiesDocumentService.GetDistinctAgreements<DistinctAgrViewModel>(functionAgr, id, dateParsed);

            return this.PartialView("SpecificEntity/_DistinctDocuments", model);
        }

        [Route("loadAllDoc")]
        public IActionResult GetAllDocuments(int id, string areaName)
        {
            var model = new DocumentOverviewViewModel { AreaName = areaName };

            string function = StringSwapper.ByArea(areaName,
                                                SqlFunctionDictionary.DocumentsFund,
                                                SqlFunctionDictionary.DocumentsSubFund,
                                                SqlFunctionDictionary.DocumentsShareClass);

            model.Documents = this.entitiesDocumentService.GetDocuments<DocumentViewModel>(function, id);

            return this.PartialView("SpecificEntity/_AllDocuments", model);
        }

        [Route("loadAllAgr")]
        public IActionResult GetAllAgreements(int id, string date, string areaName)
        {
            var model = new AgreementOverviewViewModel
            {
                AreaName = areaName,
                ContainerId = id,
                Date = date,
            };
            var dateParsed = DateTimeParser.FromWebFormat(date);

            string function = StringSwapper.ByArea(areaName,
                                             SqlFunctionDictionary.AgreementsFund,
                                             SqlFunctionDictionary.AgreementsSubFund,
                                             SqlFunctionDictionary.AgreementsShareClass);

            model.Agreements = this.entitiesDocumentService.GetAgreements<AgreementViewModel>(function, id, dateParsed);

            return this.PartialView("SpecificEntity/_AllAgreements", model);
        }

        private int GetTargetFileType(string area)
        {
            int fileType = 0;

            if (area == EndpointsConstants.FundArea)
            {
                fileType = SqlFunctionDictionary.FundFileType;
            }
            else if (area == EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)
            {
                fileType = SqlFunctionDictionary.SubFundFileType;
            }
            else if (area == EndpointsConstants.ShareClassArea)
            {
                fileType = SqlFunctionDictionary.ShareClassFileType;
            }

            return fileType;
        }
    }
}
