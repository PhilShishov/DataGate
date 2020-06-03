namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;

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
            IEnumerable<TimelineViewModel> model = null;

            if (areaName == GlobalConstants.FundAreaName)
            {
                model = this.service.GetTimeline<TimelineViewModel>(QueryDictionary.SqlFunctionTimelineFund, id);
            }
            else if (areaName == GlobalConstants.SubFundAreaName)
            {
                model = this.service.GetTimeline<TimelineViewModel>(QueryDictionary.SqlFunctionTimelineSubFund, id);
            }
            else if (areaName == GlobalConstants.ShareClassAreaName)
            {
                model = this.service.GetTimeline<TimelineViewModel>(QueryDictionary.SqlFunctionTimelineShareClass, id);
            }

            return this.PartialView("SpecificEntity/_Timeline", model);
        }
    }
}
