namespace DataGate.Web.Areas.Funds.Controllers
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

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IEntityService service;

        public FundsController(IEntityService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("funds")]
        public async Task<IActionResult> All()
        {
            var viewModel = await EntitiesVMSetup
                .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveFund);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")]
                                              EntitiesViewModel viewModel)
        {
            await EntitiesVMSetup.SetPost(viewModel, this.service, SqlFunctionDictionary.AllFund, SqlFunctionDictionary.AllActiveFund);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                return this.View(viewModel);
            }

            return this.ShowErrorAlertify(
                ErrorMessages.TableIsEmpty,
                GlobalConstants.AllActionName,
                GlobalConstants.FundsControllerName);
        }
    }
}

//foreach (var header in headers)
//{
//    this.ViewData[$"{header}SortParm"] = sortOrder == header ? $"{header}_desc" : header;
//}

//if (!string.IsNullOrEmpty(sortOrder))
//{
//    foreach (var header in headers)
//    {
//        int index = headers.ToList().IndexOf(header);

//        if (sortOrder == $"{header}_desc")
//        {
//            values = values.OrderByDescending(v => v[index]).ToList();
//            break;
//        }
//        else if (sortOrder == header)
//        {
//            values = values.OrderBy(v => v[index]).ToList();
//            break;
//        }
//    }
//}