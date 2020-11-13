namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)]
    [Authorize]
    public class SubFundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly SharedLocalizationService sharedLocalizer;

        public SubFundsController(
            IEntityService service,
            SharedLocalizationService sharedLocalizer)
        {
            this.service = service;
            this.sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        [Route("subfunds")]
        public async Task<IActionResult> All()
        {
            var viewModel = await EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveSubFund);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] 
                                              EntitiesViewModel viewModel)
        {
            await EntitiesVMSetup.SetPost(viewModel, this.service, 
                                          SqlFunctionDictionary.AllSubFund, 
                                          SqlFunctionDictionary.AllActiveSubFund);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                return this.View(viewModel);
            }

            return this.ShowError(
                  this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                  EndpointsConstants.ActionAll,
                  EndpointsConstants.DisplaySub + EndpointsConstants.FundsController);
        }
    }
}
