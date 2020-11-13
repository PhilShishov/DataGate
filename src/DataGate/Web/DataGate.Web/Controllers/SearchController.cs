namespace DataGate.Web.Controllers
{
    using System;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SearchController : BaseController
    {
        private readonly IShareClassService service;

        public SearchController(
            IShareClassService service
            )
        {
            this.service = service;
        }

        [HttpGet]
        [Route("search-results")]
        public IActionResult Result(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new BadRequestException(ErrorMessages.InvalidSearchKeyword);
            }

            var model = new SearchListAllViewModel();

            model.Date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat);
            model.SearchTerm = searchTerm;
            bool isIsin = this.service.IsIsin(searchTerm);

            if (isIsin)
            {
                var classId = this.service.ByIsin(searchTerm);
                return this.RedirectToRoute(EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea, new { area = EndpointsConstants.ShareClassArea, id = classId, date = model.Date });
            }
            model.Results = this.service.ByName(searchTerm);

            //var query = this.repository.All();
            //query = query.Where(sc =>
            //EF.Functions.Like(sc.ScOfficialShareClassName, searchTerm) ||
            //EF.Functions.Like(sc.ScIsinCode, searchTerm));

            //model.Results = query
            //    .OrderBy(sc => sc.ScOfficialShareClassName)
                //.To<ResultViewModel>().ToList();

            return this.View(model);
        }
    }
}
