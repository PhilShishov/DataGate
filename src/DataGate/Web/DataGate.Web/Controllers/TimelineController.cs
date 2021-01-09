// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Timelines;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Timelines;

    using Microsoft.AspNetCore.Mvc;

    public class TimelineController : Controller
    {
        private readonly ITimelineService service;

        public TimelineController(ITimelineService service)
        {
            this.service = service;
        }

        [Route("loadTimelines")]
        [AjaxOnly]
        public IActionResult GetAllTimelines(int id, string areaName)
        {
            string function = StringSwapper.ByArea(areaName,
                                                     SqlFunctionDictionary.TimelineFund,
                                                     SqlFunctionDictionary.TimelineSubFund,
                                                     SqlFunctionDictionary.TimelineShareClass);

            var model = this.service.All<TimelineViewModel>(function, id);

            this.ViewBag.Area = areaName;
            this.ViewBag.Route = StringSwapper.ByArea(areaName,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea);

            return this.PartialView("SpecificEntity/_Timeline", model);
        }
    }
}
