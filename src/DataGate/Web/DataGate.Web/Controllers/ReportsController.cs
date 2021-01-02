// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Services.Data.Recent;
    using DataGate.Services.Data.Reports;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Reports;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReportsController : BaseController
    {
        private readonly IRecentService recentService;
        private readonly IReportsService service;
        private readonly ITimeSeriesRepository repository;

        public ReportsController(
             IRecentService recentService,            
             IReportsService service,            
             ITimeSeriesRepository entityRepository)
        {
            this.recentService = recentService;
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

            var today = DateTime.Today;
            var date = today.BuildReportDate(type, 1);

            var headers = await this.service.All(function, date).FirstOrDefaultAsync();
            var values = await this.service.All(function, date, 1).ToListAsync();

            var viewModel = new AuMReportViewModel
            {
                Date = date,
                Headers = headers,
                Values = values,
                SelectedType = type,
            };

            await this.recentService.Save(this.User, this.Request.Path);
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

            var date = model.Date.BuildReportDate(model.SelectedType);

            model.Headers = await this.service.All(function, date).FirstOrDefaultAsync();
            model.Values = await this.service.All(function, date, 1).ToListAsync();

            return this.View(model);
        }

        [HttpGet]
        [Route("reports/{type}/timeseries/{id?}")]
        public async Task<IActionResult> TSReports(string type, int? id)
        {
            int typeIndex = (type == EndpointsConstants.DisplaySub + EndpointsConstants.FundArea) ?
                      2 : 3;

            this.SetViewDataValues(type, typeIndex);

            var today = DateTime.Today;

            var viewModel = new TimeSerieReportsListViewModel
            {
                AreaName = type,
                StartDate = today.BuildReportDate(null, 1),
                EndDate = DateTime.Today,
            };

            //viewModel.TimeSerieReports = await this.repository.GetAllTSReports(type, id, viewModel.TimeSeriesType);

            if (id.HasValue)
            {
                viewModel.Entity = await this.repository.ByName(type, id);
            }

            await this.recentService.Save(this.User, this.Request.Path);
            return this.View(viewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> TSReports(TSReportViewModel model)
        //{
        //    this.SetViewDataValues(type, typeIndex);
        //    string function = StringSwapper.ByArea(
        //                    model.SelectedType,
        //                    SqlFunctionDictionary.ReportFunds,
        //                    SqlFunctionDictionary.ReportSubFunds,
        //                    null);

        //    int day = (model.SelectedType == EndpointsConstants.FundAreaName) ?
        //        FixedDayNavValue :
        //        DateTime.DaysInMonth(model.Date.Year, model.Date.Month);
        //    var date = new DateTime(model.Date.Year, model.Date.Month, day);

        //    model.Headers = await this.service.GetAll(function, date).FirstOrDefaultAsync();
        //    model.Values = await this.service.GetAll(function, date, 1).ToListAsync();

        //    return this.View(model);
        //}

        private void SetViewDataValues(string area, int type)
        {
            this.ViewData["TimeSeriesType"] = this.repository.AllTbDomTimeSeriesType(type);
            this.ViewData["Entity"] = this.repository.All(area);
        }
    }
}
