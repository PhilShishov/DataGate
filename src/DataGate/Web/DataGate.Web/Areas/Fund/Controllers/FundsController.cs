namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    using DataGate.Common;
    using DataGate.Data.Models.Columns;
    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;

    [Area(EndpointsConstants.FundArea)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly IUserColumnRepository<UserFundColumn> repository;

        public FundsController(
            IEntityService service,
            SharedLocalizationService sharedLocalizer,
            IUserColumnRepository<UserFundColumn> repository)
        {
            this.service = service;
            this.sharedLocalizer = sharedLocalizer;
            this.repository = repository;
        }

        [HttpGet]
        [Route("funds")]
        public async Task<IActionResult> All()
        {
            var user = await this.service.GetUser(this.User);
            var userColumns = this.service.GetLayout<UserFundColumn>(this.repository, user.Id);

            var model = await EntitiesVMSetup
                .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveFund, userColumns);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,Command,PreSelectedColumns,SelectedColumns")]
                                              EntitiesViewModel model)
        {
            var user = await this.service.GetUser(this.User);
            var userColumns = this.service.GetLayout<UserFundColumn>(this.repository, user.Id);

            var columnsToDb = this.service.SetLayout<UserFundColumn>(model, user.Id, userColumns);
            await this.repository.SaveLayout(user.UserFundColumns, columnsToDb);

            await EntitiesVMSetup.SetPost(model, this.service, SqlFunctionDictionary.AllFund, SqlFunctionDictionary.AllActiveFund);

            if (model.Values != null && model.Values.Count > 0)
            {
                return this.View(model);
            }

            return this.ShowError(
                   this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate),
                   EndpointsConstants.ActionAll,
                   EndpointsConstants.FundsController);
        }
    }
}