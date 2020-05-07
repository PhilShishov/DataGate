namespace DataGate.Web.Controllers
{
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.DateTime;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Utilities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ValidateAntiForgeryToken]
    public class MediaController : BaseController
    {
        public MediaController()
        {
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

        //[HttpPost]
        //public IActionResult Read(string pdfValue)
        //{
        //    FileStreamResult fileStreamResult = null;

        //    string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Funds\");
        //    string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");

        //    string path = $"{fileLocation}{pdfValue}";

        //    if (this.HttpContext.Request.Form.ContainsKey("pdfValue"))
        //    {
        //        var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //        fileStreamResult = new FileStreamResult(fileStream, "application/pdf");
        //    }

        //    if (fileStreamResult != null)
        //    {
        //        return fileStreamResult;
        //    }

        //    return this.RedirectToAction("All");
        //}

        //[HttpGet]
        //public JsonResult DeleteAgreement(string agrName)
        //{
        //    if (!string.IsNullOrEmpty(agrName))
        //    {
        //        string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
        //        this.entitiesFileService.DeleteAgreementMapping(agrName, controllerName);

        //        string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Agreements\");
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
