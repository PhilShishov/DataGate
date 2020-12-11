namespace DataGate.Web.Areas.SubFunds.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Columns;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;

    [Area(EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)]
    [Authorize]
    public class SubFundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly IUserRepository<UserSubFundColumn> repository;

        public SubFundsController(
            IEntityService service,
            SharedLocalizationService sharedLocalizer,
            IUserRepository<UserSubFundColumn> repository)
        {
            this.service = service;
            this.sharedLocalizer = sharedLocalizer;
            this.repository = repository;
        }

        [HttpGet]
        [Route("subfunds")]
        public async Task<IActionResult> All()
        {
            var user = await this.service.GetUser(this.User);
            var userColumns = this.service.GetLayout<UserSubFundColumn>(this.repository, user.Id);

            var viewModel = await EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveSubFund, userColumns);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,Command,PreSelectedColumns,SelectedColumns")] 
                                              EntitiesViewModel model)
        {
            var user = await this.service.GetUser(this.User);
            var userColumns = this.service.GetLayout<UserSubFundColumn>(this.repository, user.Id);

            var columnsToDb = this.service.SetLayout<UserSubFundColumn>(model, user.Id, userColumns);
            await this.repository.SaveLayout(user.UserSubFundColumns, columnsToDb);

            await EntitiesVMSetup.SetPost(model, this.service, 
                                          SqlFunctionDictionary.AllSubFund, 
                                          SqlFunctionDictionary.AllActiveSubFund);

            if (model.Values != null && model.Values.Count > 0)
            {
                return this.View(model);
            }

            return this.ShowError(
                  this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                  EndpointsConstants.ActionAll,
                  EndpointsConstants.DisplaySub + EndpointsConstants.FundsController);
        }
    }
}
