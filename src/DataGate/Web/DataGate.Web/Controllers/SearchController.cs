namespace DataGate.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SearchController : Controller
    {
        private const int PerPageDefaultValue = 5;

        public SearchController()
        {
        }

        public async Task<IActionResult> Result(string searchText, int page = 1, int countPerPage = PerPageDefaultValue)
        {
            var model = new SearchListAllViewModel()
            {
                CurrentPage = page,
                PagesCount = 0,
                SearchString = searchText,
            };

            //var results = await this.service.GetAllPerPage<ResultViewModel>(page, countPerPage, searchText);

            //if (results.Count == 1)
            //{
            //    this.RedirectToAction("");
            //}

            //if (results.Count > 0)
            //{
            //    model.Results = results;
            //    model.PagesCount = (int)Math.Ceiling(results.Count() / (decimal)countPerPage);
            //}

            return this.View(model);
        }

        //public async Task<IEnumerable<T>> GetAllPerPage<T>(
        //   int page,
        //   int countPerPage,
        //   string creatorId,
        //   string searchCriteria = null,
        //   string searchText = null)
        //{
        //    var query = this.repository.AllAsNoTracking()
        //        .Where(x => x.CreatorId == creatorId);

        //    if (searchCriteria != null && searchText != null)
        //    {
        //        var filter = this.expressionBuilder.GetExpression<Category>(searchCriteria, searchText);
        //        query = query.Where(filter);
        //    }

        //    return await query
        //        .OrderByDescending(x => x.CreatedOn)
        //        .Skip(countPerPage * (page - 1))
        //        .Take(countPerPage)
        //        .To<T>()
        //        .ToListAsync();
        //}
    }
}
