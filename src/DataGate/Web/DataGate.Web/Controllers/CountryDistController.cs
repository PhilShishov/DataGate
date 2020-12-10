namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using DataGate.Common;
    using DataGate.Services.Data.CountriesDist;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.CountriesDist;

    public class CountryDistController : Controller
    {
        private readonly ICountryDistService service;

        public CountryDistController(
                        ICountryDistService service)
        {
            this.service = service;
        }

        [Route("loadCountriesDist")]
        public IActionResult GetAllCountriesDist(int id, string areaName)
        {
            string function = StringSwapper.ByArea(areaName,
                                                     null,
                                                     null,
                                                     SqlFunctionDictionary.CountryDistShareClass);

            var model = this.service.GetCountries<CountryDistViewModel>(function, id);

            this.ViewBag.Area = areaName;
            this.ViewBag.Route = StringSwapper.ByArea(areaName,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                                                        EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea);

            return this.PartialView("SpecificEntity/_CountryDist", model);
        }
    }
}
