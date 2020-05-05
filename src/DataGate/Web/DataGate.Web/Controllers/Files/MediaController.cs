namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Services.DateTime;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Utilities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MediaController : BaseController
    {
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
                    var chosenDate = DateTimeParser.WebFormat(model.ChosenDate);
                    //return GenerateFileTemplate.Pdf(model.Headers, model.Values, chosenDate, model.ControllerName);
                }
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        //[HttpPost]
        //public IActionResult ReadDocument(string pdfValue)
        //{
        //    FileStreamResult fileStreamResult = null;

        //    string fileLocation = Path.Combine(_environment.WebRootPath, @"FileFolder\Funds\");
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

        //[HttpPost]
        //public IActionResult ReadAgreement(string pdfValue)
        //{
        //    FileStreamResult fileStreamResult = null;

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

        //[ValidateAntiForgeryToken]

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
