// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using DataGate.Common;
    using DataGate.Services.Data.CountriesDist;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.CountriesDist;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class CountryDistController : Controller
    {
        private readonly ICountryDistService service;

        public CountryDistController(
                        ICountryDistService service)
        {
            this.service = service;
        }

        [Route("loadCountriesDist")]
        [AjaxOnly]
        public IActionResult GetAllCountriesDist(int id, string areaName)
        {
            string function = StringSwapper.ByArea(areaName,
                                                     null,
                                                     null,
                                                     SqlFunctionDictionary.CountryDistShareClass);

            var model = this.service.All<CountryDistViewModel>(function, id);

            this.ViewBag.Area = areaName;
            this.ViewBag.Route = StringSwapper.ByArea(areaName,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea);

            return this.PartialView("SpecificEntity/_CountryDist", model);
        }
    }
}
