namespace DataGate.Web.Areas.ShareClasses.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(GlobalConstants.ShareClassAreaName)]
    [Authorize]
    public class ShareClassesController : BaseController
    {
        private const int PerPageDefaultValue = 30;
        private readonly IEntityService service;

        public ShareClassesController(IEntityService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("shareclasses")]
        public async Task<IActionResult> All()
        {
            var viewModel = await EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service, QueryDictionary.SqlFunctionAllActiveShareClass);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] EntitiesViewModel viewModel)
        {
            await EntitiesVMSetup.SetPost(viewModel, this.service, QueryDictionary.SqlFunctionAllShareClass, QueryDictionary.SqlFunctionAllActiveShareClass);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            return this.ShowError(ErrorMessages.TableIsEmpty, GlobalConstants.AllActionName, GlobalConstants.ShareClassesControllerName);
        }
    }
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

//var model = new SearchListAllViewModel()
//{
//    CurrentPage = page,
//    PagesCount = 0,
//    SearchString = searchText,
//};

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