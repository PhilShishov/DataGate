namespace DataGate.Web.Controllers.Files
{
    using DataGate.Common;
    using DataGate.Services.DateTime;
    using DataGate.Web.InputModels.Files;
    using DataGate.Web.Utilities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ExtractionController : Controller
    {
        [HttpPost]
        public IActionResult GenerateFile(ExtractInputModel model)
        {
            if (model.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                string typeName = model.GetType().Name;

                if (model.Command == GlobalConstants.CommandExtractExcel)
                {
                    return GenerateFileTemplate.Excel(model.Entities, typeName, model.ControllerName);
                }
                else if (model.Command == GlobalConstants.CommandExtractPdf)
                {
                    var chosenDate = DateTimeParser.WebFormat(model.ChosenDate);
                    return GenerateFileTemplate.Pdf(model.Entities, chosenDate, typeName, model.ControllerName);
                }
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }
    }
}
