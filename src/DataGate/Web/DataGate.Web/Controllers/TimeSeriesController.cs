namespace DataGate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using DataGate.Services.Data.TimeSeries;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.TimeSeries;

    public class TimeSeriesController : BaseController
    {
        private readonly ITimeSeriesService service;

        public TimeSeriesController(ITimeSeriesService service)
        {
            this.service = service;
        }

        [Route("loadTimeseries")]
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

            var dates = await this.service.GetDates(functionTimeSeries, id, 1).ToListAsync();
            var providers = await this.service.GetProviders(functionProviders, id, 1).ToListAsync();
            var prices = await this.service.GetPrices(functionTimeSeries, id, 1).ToListAsync();

            var model = new TimeSeriesViewModel()
            {
                AreaName = areaName,
                TSPriceDates = dates,
                TSTypeProviders = providers,
                TSAllPriceValues = prices,
                Id = id,
            };

            return this.PartialView("SpecificEntity/_TimeSeries", model);
        }
    }
}
