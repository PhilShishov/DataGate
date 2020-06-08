namespace DataGate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.TimeSeries;
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
        public async Task<IActionResult> GetAllTimelines(int id)
        {
            var dates = await this.service.GetDates(id, 1).ToListAsync();
            var providers = await this.service.GetProviders(id, 1).ToListAsync();
            var prices = await this.service.GetData(id).ToListAsync();

            var model = new TimeSeriesViewModel()
            {
                TSPriceDates = dates,
                TSTypeProviders = providers,
                TSAllPriceValues = prices,
            };

            return this.PartialView("SpecificEntity/_TimeSeries", model);
        }
    }
}
