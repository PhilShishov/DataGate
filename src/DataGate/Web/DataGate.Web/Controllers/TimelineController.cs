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
            string function = QuerySwapper.GetResult(areaName,
                                                  FunctionDictionary.SqlFunctionTimelineFund,
                                                  FunctionDictionary.SqlFunctionTimelineSubFund,
                                                  FunctionDictionary.SqlFunctionTimelineShareClass);

            var model = this.service.GetTimeline<TimelineViewModel>(function, id);

            return this.PartialView("SpecificEntity/_Timeline", model);
        }
    }
}
