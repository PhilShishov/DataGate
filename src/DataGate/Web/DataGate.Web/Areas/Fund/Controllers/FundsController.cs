namespace DataGate.Web.Areas.Funds.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(GlobalConstants.FundAreaName)]
    [Authorize]
    public class FundsController : BaseController
    {
        private readonly IFundService service;

        public FundsController(IFundService fundsService)
        {
            this.service = fundsService;
        }

        [HttpGet]
        [Route("f/all")]
        public IActionResult All()
        {
            var model = EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult All([Bind("Date,Values,Headers,HeadersSelection,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] EntitiesViewModel model)
        {
            EntitiesVMSetup.SetPost(model, this.service);

            if (model.Values != null)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(model);
            }

            return this.ShowError(ErrorMessages.TableIsEmpty, GlobalConstants.AllActionName, GlobalConstants.FundsControllerName);
        }
    }
}
