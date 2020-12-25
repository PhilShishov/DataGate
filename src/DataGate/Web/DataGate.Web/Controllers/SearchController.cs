// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using System;

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
        private readonly IRecentService recentService;
        private readonly IShareClassService service;

        public SearchController(
            IRecentService recentService,
            IShareClassService service)
        {
            this.recentService = recentService;
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

            this.recentService.Save(this.User, this.Request.Path + this.Request.QueryString);

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
