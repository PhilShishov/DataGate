namespace DataGate.Web.Controllers.Files
{
    using DataGate.Common;
    using DataGate.Services.DateTime;
    using DataGate.Web.Utilities;
    using DataGate.Web.ViewModels.Entities;
    using Microsoft.AspNetCore.Mvc;

    public class ExtractionController : Controller
    {
        [HttpPost]
        public IActionResult GenerateExcel(EntitiesViewModel model)
        {
            if (model.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.Excel(model.Entities, typeName, GlobalConstants.FundsControllerName);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        [HttpPost]
        public IActionResult GeneratePdf(EntitiesViewModel model)
        {
            if (model.Count > GlobalConstants.RowNumberOfHeadersInTable)
            {
                var chosenDate = DateTimeParser.WebFormat(model.ChosenDate);
                string typeName = model.GetType().Name;

                return GenerateFileTemplate.Pdf(model.Entities, chosenDate, typeName, GlobalConstants.FundsControllerName);
            }

            this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableReportNotGenerated;
            return this.Redirect(GlobalConstants.FundAllUrl);
        }
    }
}
