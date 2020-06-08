namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Timelines;
    using DataGate.Web.Helpers;
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
            string function = StringSwapper.GetResult(areaName,
                                                     FunctionDictionary.SqlFunctionTimelineFund,
                                                     FunctionDictionary.SqlFunctionTimelineSubFund,
                                                     FunctionDictionary.SqlFunctionTimelineShareClass);

            var model = this.service.GetTimeline<TimelineViewModel>(function, id);

            this.ViewBag.Area = areaName;
            this.ViewBag.Route = StringSwapper.GetResult(areaName,
                                                        GlobalConstants.FundDetailsRouteName,
                                                        GlobalConstants.SubFundDetailsRouteName,
                                                        GlobalConstants.ShareClassDetailsRouteName);

            return this.PartialView("SpecificEntity/_Timeline", model);
        }
    }
}
