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
        private readonly string[] permittedExtensions = { ".pdf" };
        private readonly IWebHostEnvironment environment;
        private readonly IFileSystemService service;

        public UploadController(
                       IFileSystemService service,
                       IWebHostEnvironment environment,
                       IConfiguration config)
        {
            this.service = service;
            this.fileSizeLimit = config.GetValue<long>("FileSizeLimit");
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
                return this.ShowError(ErrorMessages.ModelUploadErrorMessage, model.RouteName, new { area = model.AreaName, id = model.Id, date = model.Date });
            }

            string path = await FileHelpers.ProcessFormFile(model.FileToUpload, this.ModelState, this.permittedExtensions,
                                                            this.fileSizeLimit, this.environment.WebRootPath);

            if (!this.ModelState.IsValid)
            {
                return this.ShowError(ErrorMessages.ModelUploadFileErrorMessage, model.RouteName, new { area = model.AreaName, id = model.Id, date = model.Date });
            }

            await this.service.UploadDocument(model);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.FileToUpload.CopyToAsync(stream);
                stream.Close();
            }

            return this.ShowInfo(InfoMessages.SuccessfulUpdate, GlobalConstants.FundDetailsRouteName, new { model.Id, model.Date });
        }

        //        //[HttpPost]
        //        //public IActionResult UploadAgreement(SpecificEntityViewModel model)
        //        //{
        //        //    SetModelValuesForSpecificView(model);

        //        //    //if (!ModelState.IsValid)
        //        //    //{
        //        //    //    return this.PartialView("SpecificEntity/_UploadAgr", model);
        //        //    //}

        //        //    var file = model.UploadAgreementFileModel.FileToUpload;

        //        //    if (file != null || file.FileName != "")
        //        //    {
        //        //        string fileExt = Path.GetExtension(file.FileName);
        //        //        string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
        //        //        string path = $"{fileLocation}{file.FileName}";

        //        //        using (var stream = new FileStream(path, FileMode.Create))
        //        //        {
        //        //            file.CopyTo(stream);
        //        //            stream.Close();
        //        //        }

        //        //        var activityTypeIdDesc = model.UploadAgreementFileModel.AgrType;
        //        //        int activityTypeId = this.context.TbDomActivityType
        //        //                .Where(at => at.AtDesc == activityTypeIdDesc)
        //        //                .Select(at => at.AtId)
        //        //                .FirstOrDefault();

        //        //        string contractDate = model.UploadAgreementFileModel.ContractDate.ToString("yyyyMMdd");
        //        //        string activationDate = model.UploadAgreementFileModel.ActivationDate.ToString("yyyyMMdd");
        //        //        string expirationDate = model.UploadAgreementFileModel.ExpirationDate?.ToString("yyyyMMdd");

        //        //        int statusId = this.context.TbDomAgreementStatus
        //        //            .Where(s => s.ASDesc == model.UploadAgreementFileModel.Status)
        //        //            .Select(s => s.ASId)
        //        //            .FirstOrDefault();

        //        //        int companyId = this.context.TbCompanies
        //        //            .Where(c => c.CName == model.UploadAgreementFileModel.Company)
        //        //            .Select(c => c.CId)
        //        //            .FirstOrDefault();

        //        //        this.entitiesFileService.AddAgreementToSpecificEntity(
        //        //                                            file.FileName,
        //        //                                            fileExt,
        //        //                                            model.EntityId,
        //        //                                            activityTypeId,
        //        //                                            contractDate,
        //        //                                            activationDate,
        //        //                                            expirationDate,
        //        //                                            statusId,
        //        //                                            companyId,
        //        //                                            model.ControllerName);
        //        //    }

        //        //    this.ModelState.Clear();
        //        //    return this.RedirectToAction("ViewEntitySE", new { model.EntityId, model.ChosenDate });
        //        //}
    }
}
