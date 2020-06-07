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

        public TimeSeriesController(
                        ITimeSeriesService service)
        {
            this.service = service;
        }

        [Route("loadTimeseries")]
        public async Task<IActionResult> GetAllTimelines(int id)
        {
            var model = new TimeSeriesViewModel()
            {
                TSPriceDates = await this.service.GetDates(id).ToListAsync(),
                TSTypeProviders = await this.service.GetProviders(id).ToListAsync(),
                TSAllPriceValues = await this.service.GetData(id).ToListAsync(),
            };

            return this.PartialView("SpecificEntity/_TimeSeries", model);
        }
    }
}
