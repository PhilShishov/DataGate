namespace DataGate.Web.Areas.Funds.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Http;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.Helpers;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Entities;
    using Microsoft.AspNetCore.Identity;
    using DataGate.Data.Models.Users;

    [Area(EndpointsConstants.FundArea)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IEntityService service;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly UserManager<ApplicationUser> userManager;

        public FundsController(
            IEntityService service,
            SharedLocalizationService sharedLocalizer,
            UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.sharedLocalizer = sharedLocalizer;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("funds")]
        public async Task<IActionResult> All()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var model = await EntitiesVMSetup
                .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveFund);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> All([Bind("Date,Values,Headers,IsActive,Command,PreSelectedColumns,SelectedColumns")]
                                              EntitiesViewModel model)
        {
            //var user = await this.userManager.GetUserAsync(this.User);

            //var layout = user.UserLayout();

            //if (layout != null)
            //{
            //    model.SelectedColumns = layout.SelectedColumns;
            //}

            //if (model.Command == "Save")
            //{
            //    layout.SelectedColumns = model.SelectedColumns;
            //}

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