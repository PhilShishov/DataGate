namespace DataGate.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.Recent;
    using DataGate.Web.ViewModels.Search;

    [Authorize]
    public class SearchController : BaseController
    {
        private readonly IRecentService serviceRecent;
        private readonly IShareClassService service;

        public SearchController(
            IRecentService serviceRecent,
            IShareClassService service)
        {
            this.serviceRecent = serviceRecent;
            this.service = service;
        }

        [HttpGet]
        [Route("search-results")]
        public IActionResult Result(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new BadRequestException(ErrorMessages.InvalidSearchKeyword);
            }

            this.serviceRecent.Save(this.User, Request.Path, Request.QueryString);

            var model = new SearchResultsViewModel
            {
                Date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                SearchTerm = searchTerm
            };

            bool isIsin = this.service.IsIsin(model.CleanedSearch);

            if (isIsin)
            {
                var classId = this.service.ByIsin(model.CleanedSearch);
                return this.RedirectToRoute(
                    EndpointsConstants.RouteDetails + EndpointsConstants.ShareClassArea, 
                    new { area = EndpointsConstants.ShareClassArea, id = classId, date = model.Date });
            }
            model.Results = this.service.ByName(model.CleanedSearch);

            return this.View(model);
        }
    }
}
