namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Web.Filters;
    using DataGate.Web.Infrastructure.Filters;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Utilities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    //[ValidateAntiForgeryToken]
    public class MediaController : BaseController
    {
        private readonly IWebHostEnvironment environment;
        private readonly IFileSystemService service;

        public MediaController(
                    IWebHostEnvironment environment,
                    IFileSystemService fileService)
        {
            this.environment = environment;
            this.service = fileService;
        }

        [HttpPost]
        public JsonResult GenerateReport(DownloadInputModel model)
        {
            string fileName = string.Empty;
            if (model.TableValues != null && model.TableValues.Count > 0)
            {
                IEnumerable<string> tableHeaders = model.TableValues.FirstOrDefault();

                if (model.Command == GlobalConstants.CommandExtractExcel)
                {
                    fileName = GenerateFileTemplate.Excel(tableHeaders, model.TableValues, model.ControllerName);
                }
                else if (model.Command == GlobalConstants.CommandExtractPdf)
                {
                    var date = DateTimeParser.WebFormat(model.Date);

                    //if (tableHeaders.ToList().Count > GlobalConstants.NumberOfAllowedColumnsInPdfView)
                    //{
                    //    var errorMessage = ErrorMessages.TooManyColumns;
                    //    return this.Json(ErrorMessages.TooManyColumns, model.RouteName);
                    //}

                    fileName = GenerateFileTemplate.Pdf(tableHeaders, model.TableValues, date, model.ControllerName);
                }
            }

            return this.Json(new { fileName = fileName });
        }

        [HttpGet]
        [DeleteFileAttribute]
        public IActionResult Download(string fileName)
        {
            string fullPath = Path.Combine(Path.GetTempPath(), fileName);

            string streamMimeType = Path.GetExtension(fileName) == GlobalConstants.ExcelFileExtension ?
                                    GlobalConstants.ExcelStreamMimeType : GlobalConstants.PdfStreamMimeType;

            return this.PhysicalFile(fullPath, streamMimeType, fileName);
        }

        [HttpPost]
        public IActionResult Read(string docValue, string agrValue, string areaName)
        {
            if (!string.IsNullOrEmpty(areaName))
            {
                string path = this.GetTargetPath(ref docValue, agrValue, areaName);

                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                FileStreamResult fileStreamResult = new FileStreamResult(fileStream, $"{GlobalConstants.PdfStreamMimeType}");

                if (fileStreamResult != null)
                {
                    return fileStreamResult;
                }
            }

            return this.RedirectToRoute(GlobalConstants.AllFundsRouteName);
        }

        [EndpointExceptionFilter]
        [Route("media/delete")]
        public async Task<JsonResult> Delete(string docValue, string agrValue, string areaName)
        {
            if (!string.IsNullOrEmpty(areaName))
            {
                string path = this.GetTargetPath(ref docValue, agrValue, areaName);

                if (System.IO.File.Exists(path))
                {
                    if (string.IsNullOrEmpty(agrValue))
                    {
                        await this.service.DeleteDocument(docValue, areaName);
                    }
                    else
                    {
                        await this.service.DeleteAgreement(agrValue, areaName);
                    }

                    System.IO.File.Delete(path);
                    return this.Json(new { data = Path.GetFileNameWithoutExtension(docValue) });
                }
            }

            return this.Json(new { data = "false" });
        }

        private string GetTargetPath(ref string docValue, string agrValue, string areaName)
        {
            string targetLocation;
            if (string.IsNullOrEmpty(docValue))
            {
                targetLocation = "Agreement";
                docValue = agrValue;
            }
            else
            {
                targetLocation = areaName;
            }

            string fileLocation = Path.Combine(this.environment.WebRootPath, @$"FileFolder\{targetLocation}\");
            string path = $"{fileLocation}{docValue}";
            return path;
        }
    }
}
