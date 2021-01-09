// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers.Files
{
    using DataGate.Common;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Attributes.Validation;
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
        [AjaxOnly]
        public IActionResult Document(LoadDocumentDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadDocumentInputModel>(dto);

            int fileType = this.GetTargetFileType(model.AreaName);
            model.DocumentTypes = this.service.GetDocumentsFileTypes(fileType);

            return this.PartialView("Upload/_UploadDocument", model);
        }

        [Route("loadAgrUpload")]
        [AjaxOnly]
        public IActionResult Agreement(LoadAgreementDto dto)
        {
            var model = AutoMapperConfig.MapperInstance.Map<UploadAgreementInputModel>(dto);

            model.AgreementsStatus = this.repository.AllAgreementStatus();
            model.Companies = this.repository.AllCompanies();

            int fileType = this.GetTargetFileType(model.AreaName);
            model.AgreementsFileTypes = this.repository.AllAgreementsFileTypes(fileType);

            return this.PartialView("Upload/_UploadAgreement", model);
        }

        [Route("loadDistinct")]
        [AjaxOnly]
        public IActionResult GetDistinct(int id, string date, string areaName)
        {
            var model = new DistinctOverviewViewModel { AreaName = areaName };
            var dateParsed = DateTimeExtensions.FromWebFormat(date);

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
        [AjaxOnly]
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
        [AjaxOnly]
        public IActionResult GetAllAgreements(int id, string date, string areaName)
        {
            var model = new AgreementOverviewViewModel
            {
                AreaName = areaName,
                ContainerId = id,
                Date = date,
            };
            var dateParsed = DateTimeExtensions.FromWebFormat(date);

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
