namespace DataGate.Web.Controllers
{
    using System;

    using DataGate.Common;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SearchController : Controller
    {
        private readonly IShareClassService service;

        public SearchController(IShareClassService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Result(string searchTerm)
        {
            var model = new SearchListAllViewModel();
            if (searchTerm != null)
            {
                var date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat);
                bool isIsin = this.service.IsIsin(searchTerm);

                if (isIsin)
                {
                    var classId = this.service.GetClassByIsin(searchTerm);
                    return this.RedirectToRoute(GlobalConstants.ShareClassDetailsRouteName, new { area = GlobalConstants.ShareClassAreaName, id = classId, date = date });
                }

                var results = this.service.SearchClassesByName(searchTerm);
            }

            return this.View(model);
        }
    }
}
