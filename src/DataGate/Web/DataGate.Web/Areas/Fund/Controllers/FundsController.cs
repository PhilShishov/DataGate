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
            var viewModel = await EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service, FunctionDictionary.SqlFunctionAllActiveFund);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] EntitiesViewModel viewModel)
        {
            await EntitiesVMSetup.SetPost(viewModel, this.service, FunctionDictionary.SqlFunctionAllFund, FunctionDictionary.SqlFunctionAllActiveFund);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            return this.ShowError(ErrorMessages.TableIsEmpty, GlobalConstants.AllActionName, GlobalConstants.FundsControllerName);
        }
    }
}
