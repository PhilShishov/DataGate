namespace DataGate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.TimeSeries;
    using DataGate.Web.Helpers;
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
        public async Task<IActionResult> GetAllTimelines(int id, string areaName)
        {
            string functionDates = StringSwapper.ByArea(
                        areaName,
                        null,
                        SqlFunctionTimeSeries.DatesSubFund,
                        SqlFunctionTimeSeries.DatesShareClass);
            string functionProviders = StringSwapper.ByArea(
                        areaName,
                        null,
                        SqlFunctionTimeSeries.ProvidersSubFund,
                        SqlFunctionTimeSeries.ProvidersShareClass);
            string functionPrices = StringSwapper.ByArea(
                        areaName,
                        null,
                        SqlFunctionTimeSeries.PricesSubFund,
                        SqlFunctionTimeSeries.PricesShareClass);

            var dates = await this.service.GetDates(functionDates, id, 1).ToListAsync();
            var providers = await this.service.GetProviders(functionProviders, id, 1).ToListAsync();
            var prices = await this.service.GetPrices(functionPrices, id).ToListAsync();

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
