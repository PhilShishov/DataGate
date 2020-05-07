namespace DataGate.Web.Controllers.Files
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UploadController : Controller
    {
        //[HttpPost("Upload")]
        //public async Task<IActionResult> Upload(List<IFormFile> files)
        //{
        //    var filePath = Path.GetTempFileName(); // Full path to file in temp location

        //    foreach (var formFile in files.Where(f => f.Length > 0))
        //    {
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await formFile.CopyToAsync(stream);
        //        }
        //    } // Copy files to FileSystem using Streams

        //    var bytes = files.Sum(f => f.Length);
        //    return Ok(new { count = files.Count, bytes, filePath });
        //}

        //        [HttpPost]
        //        public IActionResult UploadProspectus(SpecificEntityViewModel model)
        //        {
        //            this.SetModelValuesForSpecificView(model);

        //            var file = model.UploadEntityFileModel.FileToUpload;

        //            if (file != null || file.FileName != string.Empty)
        //            {
        //                //                private string[] permittedExtensions = { ".txt", ".pdf" };

        //                //        var ext = Path.GetExtension(uploadedFileName).ToLowerInvariant();

        //                //if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
        //                //{
        //                //    // The extension is invalid ... discontinue processing the file
        //                //}

        //                //                private static readonly Dictionary<string, List<byte[]>> _fileSignature =
        //                //    new Dictionary<string, List<byte[]>>
        //                //{
        //                //    { ".jpeg", new List<byte[]>
        //                //        {
        //                //            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
        //                //            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
        //                //            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
        //                //        }
        //                //    },
        //                //};

        //                //using (var reader = new BinaryReader(uploadedFileData))
        //                //{
        //                //    var signatures = _fileSignature[ext];
        //                //    var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

        //                //    return signatures.Any(signature => 
        //                //        headerBytes.Take(signature.Length).SequenceEqual(signature));
        //                //}

        //                //                Size validation
        //                //Limit the size of uploaded files.

        //                //In the sample app, the size of the file is limited to 2 MB(indicated in bytes).The limit is supplied via Configuration from the appsettings.json file:

        //                //JSON

        //                //Copy
        //                //{
        //                //                    "FileSizeLimit": 2097152
        //                //}
        //                //                The FileSizeLimit is injected into PageModel classes:

        //                //C#

        //                //Copy
        //                //public class BufferedSingleFileUploadPhysicalModel : PageModel
        //                //        {
        //                //            private readonly long _fileSizeLimit;

        //                //            public BufferedSingleFileUploadPhysicalModel(IConfiguration config)
        //                //            {
        //                //                _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        //                //            }

        //                //    ...
        //                //}
        //                //        When a file size exceeds the limit, the file is rejected:

        //                //C#

        //                //Copy
        //                //if (formFile.Length > _fileSizeLimit)
        //                //{
        //                //    // The file is too large ... discontinue processing the file
        //                //}

        //                // DTO
        //                string fileExt = Path.GetExtension(file.FileName);
        //                string fileLocation = Path.Combine(this.environment.WebRootPath, @"FileFolder\Funds\");
        //                string path = $"{fileLocation}{file.FileName}";

        //                // file exists

        //                using (var stream = new FileStream(path, FileMode.Create))
        //                {
        //                    file.CopyTo(stream);
        //                    stream.Close();
        //                }

        //                string startConnection = model.StartConnection.ToString("yyyyMMdd");
        //                string endConnection = model.EndConnection?.ToString("yyyyMMdd");

        //                var prosFileTypeDesc = model.UploadEntityFileModel.DocumentType;
        //                int prosFileTypeId = 0;
        //                //this.context.TbDomFileType
        //                //    .Where(ft => ft.FiletypeDesc == prosFileTypeDesc)
        //                //    .Select(ft => ft.FiletypeId)
        //                //    .FirstOrDefault();

        //                this.entitiesFileService.AddDocumentToSpecificEntity(
        //                                                    file.FileName,
        //                                                    model.EntityId,
        //                                                    startConnection,
        //                                                    endConnection,
        //                                                    fileExt,
        //                                                    prosFileTypeId,
        //                                                    model.ControllerName);
        //            }

        //            return this.RedirectToAction("ByIdAndDate", new { model.EntityId, model.ChosenDate });
        //        }

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