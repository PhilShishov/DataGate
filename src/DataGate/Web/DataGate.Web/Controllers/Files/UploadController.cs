namespace DataGate.Web.Controllers.Files
{
    using System.IO;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Web.Helpers;
    using DataGate.Web.InputModels.Files;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Authorize]
    public class UploadController : BaseController
    {
        private readonly long fileSizeLimit;
        private readonly string[] permittedExtensions = { GlobalConstants.PdfFileExtension };
        private readonly IWebHostEnvironment environment;
        private readonly IFileSystemService service;

        public UploadController(
                       IFileSystemService service,
                       IWebHostEnvironment environment,
                       IConfiguration config)
        {
            this.service = service;
            this.fileSizeLimit = config.GetValue<long>(GlobalConstants.FileSizeLimitConfiguration);
            this.environment = environment;
        }

        [HttpPost]
        [ActionName("Document")]
        public async Task<IActionResult> OnPostUploadDocumentAsync(
            [Bind("DocumentType", "FileToUpload", "StartConnection", "EndConnection",
                  "Date", "Id", "RouteName", "AreaName")] UploadDocumentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ShowError(
                    ErrorMessages.ModelUploadErrorMessage,
                    model.RouteName,
                    new { area = model.AreaName, id = model.Id, date = model.Date });
            }

            string path = await FileHelpers.ProcessFormFile(model.FileToUpload, this.ModelState, this.permittedExtensions,
                                                            this.fileSizeLimit, this.environment.WebRootPath, model.AreaName, false);

            if (!this.ModelState.IsValid)
            {
                return this.ShowError(
                    ErrorMessages.ModelUploadFileErrorMessage,
                    model.RouteName,
                    new { area = model.AreaName, id = model.Id, date = model.Date });
            }

            await this.service.UploadDocument(model);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.FileToUpload.CopyToAsync(stream);
                stream.Close();
            }

            return this.ShowInfo(
                InfoMessages.FileUploaded,
                model.RouteName,
                new { area = model.AreaName, id = model.Id, date = model.Date });
        }

        [HttpPost]
        [ActionName("Agreement")]
        public async Task<IActionResult> OnPostUploadAgreementAsync(
            [Bind("AgrType", "ContractDate", "ActivationDate", "ExpirationDate", "Company", "Status", "FileToUpload",
                  "Date", "Id", "RouteName", "AreaName")]UploadAgreementInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ShowError(
                    ErrorMessages.ModelUploadErrorMessage,
                    model.RouteName,
                    new { area = model.AreaName, id = model.Id, date = model.Date });
            }

            string path = await FileHelpers.ProcessFormFile(model.FileToUpload, this.ModelState, this.permittedExtensions,
                                                            this.fileSizeLimit, this.environment.WebRootPath, model.AreaName, true);

            if (!this.ModelState.IsValid)
            {
                return this.ShowError(
                    ErrorMessages.ModelUploadFileErrorMessage,
                    model.RouteName,
                    new { area = model.AreaName, id = model.Id, date = model.Date });
            }

            await this.service.UploadAgreement(model);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.FileToUpload.CopyToAsync(stream);
                stream.Close();
            }

            return this.ShowInfo(
                InfoMessages.FileUploaded,
                model.RouteName,
                new { area = model.AreaName, id = model.Id, date = model.Date });
        }
    }
}
