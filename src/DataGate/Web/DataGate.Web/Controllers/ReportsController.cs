namespace DataGate.Web.Controllers
{
    using System;
    using System.Text.RegularExpressions;

    using DataGate.Common;
    using DataGate.Services.Data.Reports;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Reports;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReportsController : BaseController
    {
        private const int FixedDayNavValue = 5;
        private readonly IReportsService service;

        public ReportsController(
            IReportsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("reports")]
        public IActionResult Overview()
        {
            return this.View();
        }

        [HttpGet]
        [Route("reports/{type}")]
        public IActionResult All(string type)
        {
            string function = StringSwapper.ByArea(
                            type,
                            null,
                            SqlFunctionDictionary.ReportsSubFunds,
                            null);

            var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, FixedDayNavValue);
            var reports = this.service.GetAll<ReportViewModel>(function, date);

            var viewModel = new ReportOverviewViewModel()
            {
                Date = date,
                Reports = reports,
                SelectedType = Regex.Replace(type, "(\\B[A-Z])", " $1"),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult All(ReportOverviewViewModel model)
        {
            string function = StringSwapper.ByArea(
                            model.SelectedType,
                            null,
                            SqlFunctionDictionary.ReportsSubFunds,
                            null);

            var parsedDate = new DateTime(model.Date.Year, model.Date.Month, FixedDayNavValue);

            model.Reports = this.service.GetAll<ReportViewModel>(function, parsedDate);

            if (model.Reports != null)
            {
                return this.View(model);
            }

            this.ShowErrorAlertify(ErrorMessages.TableIsEmpty);
            return this.View(model);
        }
    }
}
