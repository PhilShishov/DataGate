namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Timelines;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Timelines;

    using Microsoft.AspNetCore.Mvc;

    public class TimelineController : Controller
    {
        private readonly ITimelineService service;

        public TimelineController(
                        ITimelineService service)
        {
            this.service = service;
        }

        [Route("loadTimelines")]
        public IActionResult GetAllTimelines(int id, string areaName)
        {
            string function = StringSwapper.ByArea(areaName,
                                                     SqlFunctionDictionary.TimelineFund,
                                                     SqlFunctionDictionary.TimelineSubFund,
                                                     SqlFunctionDictionary.TimelineShareClass);

            var model = this.service.GetTimeline<TimelineViewModel>(function, id);

            this.ViewBag.Area = areaName;
            this.ViewBag.Route = StringSwapper.ByArea(areaName,
                                                        GlobalConstants.FundDetailsRouteName,
                                                        GlobalConstants.SubFundDetailsRouteName,
                                                        GlobalConstants.ShareClassDetailsRouteName);

            return this.PartialView("SpecificEntity/_Timeline", model);
        }
    }
}
