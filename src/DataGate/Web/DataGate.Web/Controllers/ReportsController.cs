namespace DataGate.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Reports;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Reports;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReportsController : BaseController
    {
        private const int FixedDayNavValue = 5;
        private readonly IReportsService service;
        private readonly IEntityRepository repository;

        public ReportsController(
            IReportsService service,
            IEntityRepository entityRepository)
        {
            this.service = service;
            this.repository = entityRepository;
        }

        [HttpGet]
        [Route("reportoverview")]
        public IActionResult MainOverview()
        {
            return this.View();
        }

        [HttpGet]
        [Route("reports/{type}")]
        public IActionResult SubOverview(string type)
        {
            var viewModel = new AuMReportViewModel()
            {
                SelectedType = type,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Route("reports/{type}/aum")]
        public async Task<IActionResult> AuMReports(string type)
        {
            string function = StringSwapper.ByArea(
                            type,
                            SqlFunctionDictionary.ReportFunds,
                            SqlFunctionDictionary.ReportSubFunds,
                            null);
            int day = (type == GlobalConstants.FundAreaName) ?
                FixedDayNavValue :
                DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month - 1);
            var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, day);
            var headers = await this.service.GetAll(function, date).FirstOrDefaultAsync();
            var values = await this.service.GetAll(function, date, 1).ToListAsync();

            var viewModel = new AuMReportViewModel
            {
                Date = date,
                Headers = headers,
                Values = values,
                SelectedType = type,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AuMReports(AuMReportViewModel model)
        {
            string function = StringSwapper.ByArea(
                            model.SelectedType,
                            SqlFunctionDictionary.ReportFunds,
                            SqlFunctionDictionary.ReportSubFunds,
                            null);

            int day = (model.SelectedType == GlobalConstants.FundAreaName) ?
                FixedDayNavValue :
                DateTime.DaysInMonth(model.Date.Year, model.Date.Month);
            var date = new DateTime(model.Date.Year, model.Date.Month, day);

            model.Headers = await this.service.GetAll(function, date).FirstOrDefaultAsync();
            model.Values = await this.service.GetAll(function, date, 1).ToListAsync();

            return this.View(model);
        }

        [HttpGet]
        [Route("reports/{type}/timeseries/{id?}")]
        public async Task<IActionResult> TSReports(string type, int? id)
        {
            int typeIndex = (type == GlobalConstants.SubFundAreaName) ?
                      2 : 3;  

            this.SetViewDataValues(type, typeIndex);

            var viewModel = new TSReportOverviewViewModel
            {
                AreaName = type,
                StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.Today.Day),
                EndDate = DateTime.Today,
            };

            if (id.HasValue)
            {
                viewModel.Entity = await this.repository.ByName(type, id);
            }

            return this.View(viewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> AuMReports(TSReportViewModel model)
        //{
        //    string function = StringSwapper.ByArea(
        //                    model.SelectedType,
        //                    SqlFunctionDictionary.ReportFunds,
        //                    SqlFunctionDictionary.ReportSubFunds,
        //                    null);

        //    int day = (model.SelectedType == GlobalConstants.FundAreaName) ?
        //        FixedDayNavValue :
        //        DateTime.DaysInMonth(model.Date.Year, model.Date.Month);
        //    var date = new DateTime(model.Date.Year, model.Date.Month, day);

        //    model.Headers = await this.service.GetAll(function, date).FirstOrDefaultAsync();
        //    model.Values = await this.service.GetAll(function, date, 1).ToListAsync();

        //    return this.View(model);
        //}

        private void SetViewDataValues(string area, int type)
        {
            this.ViewData["TimeSeriesType"] = this.repository.GetAllTbDomTimeSeriesType(type);
            this.ViewData["Entity"] = this.repository.GetAll(area);
        }
    }
}
