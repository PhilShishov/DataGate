namespace DataGate.Web.Controllers
{
    using System.IO;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.DateTime;
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

        public MediaController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost]
        public IActionResult Download(DownloadInputModel model)
        {
            if (model.Values != null)
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
        public IActionResult Read(string docValue, string agrValue, string controllerName)
        {
            FileStreamResult fileStreamResult = null;

            if (!string.IsNullOrEmpty(controllerName))
            {
                string path = this.GetTargetPath(ref docValue, agrValue, controllerName);

                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                fileStreamResult = new FileStreamResult(fileStream, $"{GlobalConstants.PdfStreamMimeType}");

                if (fileStreamResult != null)
                {
                    return fileStreamResult;
                }
            }

            return this.RedirectToRoute(GlobalConstants.AllFundsRouteName);
        }

        //[EndpointExceptionFilter]
        [HttpGet]
        public JsonResult Delete(string docValue, string agrValue, string controllerName)
        {
            if (!string.IsNullOrEmpty(controllerName))
            {
                string path = this.GetTargetPath(ref docValue, agrValue, controllerName);

                if (System.IO.File.Exists(path))
                {
                    //this.fileService.DeleteMapping(docValue, agrValue, controllerName);
                    //System.IO.File.Delete(path);
                    return this.Json(new { data = Path.GetFileNameWithoutExtension(agrValue) });
                }
            }

            return this.Json(new { data = "false" });
        }

        private string GetTargetPath(ref string pdfValue, string agrValue, string controllerName)
        {
            string targetLocation;
            if (string.IsNullOrEmpty(pdfValue))
            {
                targetLocation = "Agreement";
                pdfValue = agrValue;
            }
            else
            {
                targetLocation = controllerName.Replace("Details", string.Empty);
            }

            string fileLocation = Path.Combine(this.environment.WebRootPath, @$"FileFolder\{targetLocation}\");
            string path = $"{fileLocation}{pdfValue}";
            return path;
        }
    }
}
