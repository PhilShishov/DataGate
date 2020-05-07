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
            if (model.Values.Count > 0)
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
        public IActionResult Read(string pdfValue, string agrValue, string controllerName)
        {
            FileStreamResult fileStreamResult = null;

            if (!string.IsNullOrEmpty(controllerName))
            {
                string correctLocation;
                if (string.IsNullOrEmpty(pdfValue))
                {
                    correctLocation = "Agreement";
                    pdfValue = agrValue;
                }
                else
                {
                    correctLocation = controllerName.Replace("Details", string.Empty);
                }

                string fileLocation = Path.Combine(this.environment.WebRootPath, @$"FileFolder\{correctLocation}\");
                string path = $"{fileLocation}{pdfValue}";

                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    fileStreamResult = new FileStreamResult(fileStream, $"{GlobalConstants.PdfStreamMimeType}");

                    if (fileStreamResult != null)
                    {
                        return fileStreamResult;
                    }
                }
            }

            return this.RedirectToAction("All");
        }

        //[HttpGet]
        //public JsonResult Delete(string agrName)
        //{
        //    if (!string.IsNullOrEmpty(agrName))
        //    {
        //        string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
        //        this.entitiesFileService.DeleteAgreementMapping(agrName, controllerName);

        //        string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreement\");
        //        string path = $"{fileLocation}{agrName}";

        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //            return Json(new { data = Path.GetFileNameWithoutExtension(agrName) });
        //        }
        //    }

        //    return Json(new { data = "false" });
        //}
    }
}
