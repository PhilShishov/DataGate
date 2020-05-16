namespace DataGate.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Web.Filters;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Utilities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ValidateAntiForgeryToken]
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
        public IActionResult Download(DownloadInputModel model)
        {
            if (model.Values != null && model.Values.Count > 0)
            {
                if (model.Command == GlobalConstants.CommandExtractExcel)
                {
                    return GenerateFileTemplate.Excel(model.Headers, model.Values, model.ControllerName);
                }
                else if (model.Command == GlobalConstants.CommandExtractPdf)
                {
                    var date = DateTimeParser.WebFormat(model.Date);

                    if (model.Headers.ToList().Count > GlobalConstants.NumberOfAllowedColumnsInPdfView)
                    {
                        return this.ShowError(ErrorMessages.TooManyColumns, model.RouteName);
                    }

                    return GenerateFileTemplate.Pdf(model.Headers, model.Values, date, model.ControllerName);
                }
            }

            return this.ShowError(ErrorMessages.TableReportNotGenerated, model.RouteName);
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
