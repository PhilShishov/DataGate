// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.TimeSeries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.TimeSeries;

    using Microsoft.AspNetCore.Mvc;

    public class TimeSeriesController : BaseController
    {
        private readonly ITimeSeriesService service;

        public TimeSeriesController(ITimeSeriesService service)
        {
            this.service = service;
        }

        [Route("loadTimeseries")]
        [AjaxOnly]
        public async Task<IActionResult> GetAllTimeSeries(int id, string areaName)
        {
            string functionProviders = StringSwapper.ByArea(
                        areaName,
                        null,
                        SqlFunctionTimeSeries.ProvidersSubFund,
                        SqlFunctionTimeSeries.ProvidersShareClass);

            string functionTimeSeries = StringSwapper.ByArea(
                        areaName,
                        null,
                        SqlFunctionTimeSeries.TimeSeriesSF,
                        SqlFunctionTimeSeries.TimeSeriesSC);

            bool isMainProvider = true;

            var provider = await this.service.GetProviders(string.Format(functionProviders, id), 1, isMainProvider).FirstOrDefaultAsync();
            var dates = await this.service.GetDates(string.Format(functionTimeSeries, id, provider), 1).ToListAsync();
            var prices = await this.service.GetPrices(string.Format(functionTimeSeries, id, provider), 1).ToListAsync();

            var model = new TimeSeriesViewModel()
            {
                AreaName = areaName,
                TSPriceDates = dates,
                TSTypeProvider = provider,
                TSAllPriceValues = prices,
                Id = id,
            };

            return this.PartialView("SpecificEntity/_TimeSeries", model);
        }
    }
}
