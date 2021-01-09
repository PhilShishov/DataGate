// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers.Files
{
    using System.IO;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Files;
    using DataGate.Services.Mapping;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Resources;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Authorize]
    public class UploadController : BaseController
    {
        private const string UploadDocumentPartialView = "Upload/_UploadDocument";
        private const string UploadAgreementPartialView = "Upload/_UploadAgreement";

        private readonly long fileSizeLimit;
        private readonly string[] permittedExtensions = { GlobalConstants.PdfFileExtension };
        private readonly IWebHostEnvironment environment;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly IFileService service;

        public UploadController(
                       IFileService service,
                       IWebHostEnvironment environment,
                       IConfiguration config,
                       SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.fileSizeLimit = config.GetValue<long>(GlobalConstants.FileSizeLimitConfiguration);
            this.environment = environment;
            this.sharedLocalizer = sharedLocalizer;
        }

        [HttpPost, AjaxOnly]
        [ActionName("Document")]
        public async Task<IActionResult> OnPostUploadDocumentAsync(
            [Bind("DocumentType", "DocumentTypes", "FileToUpload", "StartConnection", "EndConnection",
                  "Date", "Id", "RouteName", "AreaName")] UploadDocumentInputModel model)
        {
            if (!this.ModelState.IsValid || model.EndConnection <= model.StartConnection)
            {
                return this.PartialView(UploadDocumentPartialView, model);
            }

            string path = await FileHelper.ProcessFormFile(model.FileToUpload, this.ModelState, this.permittedExtensions,
                                                            this.fileSizeLimit, this.environment.WebRootPath, model.AreaName, false);

            if (!this.ModelState.IsValid)
            {
                return this.PartialView(UploadDocumentPartialView, model);
            }

            var dto = AutoMapperConfig.MapperInstance.Map<OnUploadSuccessDto>(model);

            await this.service.UploadDocument(model);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.FileToUpload.CopyToAsync(stream);
                stream.Close();
            }

            return this.Json(new { success = true, dto = dto });
        }

        [HttpPost, AjaxOnly]
        [ActionName("Agreement")]
        public async Task<IActionResult> OnPostUploadAgreementAsync(
            [Bind("AgrType", "AgreementsFileTypes", "AgreementsStatus", "Companies", "ContractDate",
                  "ActivationDate", "ExpirationDate", "Company", "Status", "FileToUpload",
                  "Date", "Id", "RouteName", "AreaName")] UploadAgreementInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(UploadAgreementPartialView, model);
            }

            string path = await FileHelper.ProcessFormFile(model.FileToUpload, this.ModelState, this.permittedExtensions,
                                                            this.fileSizeLimit, this.environment.WebRootPath, model.AreaName, true);

            if (!this.ModelState.IsValid)
            {
                return this.PartialView(UploadAgreementPartialView, model);
            }

            var dto = AutoMapperConfig.MapperInstance.Map<OnUploadSuccessDto>(model);
            await this.service.UploadAgreement(model);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.FileToUpload.CopyToAsync(stream);
                stream.Close();
            }

            return this.Json(new { success = true, dto = dto });
        }

        [AjaxOnly]
        public IActionResult OnUploadSuccess(
          [Bind("AreaName, Date, Id, RouteName, IsFee, FileId")] OnUploadSuccessDto dto)
        {
            if (dto.IsFee)
            {
                return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.FileUploaded),
                EndpointsConstants.RouteFees,
                new
                {
                    fileId = dto.FileId,
                    id = dto.Id,
                    date = dto.Date,
                    areaName = dto.AreaName,
                });
            }

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.FileUploaded),
                dto.RouteName,
                new { area = dto.AreaName, id = dto.Id, date = dto.Date });
        }
    }
}
