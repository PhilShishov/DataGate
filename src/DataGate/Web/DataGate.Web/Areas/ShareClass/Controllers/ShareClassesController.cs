namespace DataGate.Web.Areas.ShareClasses.Controllers
{
    using DataGate.Common;
    using DataGate.Services.Data.ShareClasses.Contracts;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Controllers;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area(GlobalConstants.ShareClassAreaName)]
    [Authorize]
    public class ShareClassesController : BaseController
    {
        private readonly IShareClassService service;

        public ShareClassesController(IShareClassService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("shareclasses")]
        public IActionResult All()
        {
            var viewModel = EntitiesVMSetup.SetGet<EntitiesViewModel>(this.service);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult All([Bind("Date,Values,Headers,IsActive,PreSelectedColumns,SelectedColumns,SelectTerm")] EntitiesViewModel viewModel)
        {
            EntitiesVMSetup.SetPost(viewModel, this.service);

            if (viewModel.Values != null && viewModel.Values.Count > 0)
            {
                this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfulUpdate;
                return this.View(viewModel);
            }

            return this.ShowError(ErrorMessages.TableIsEmpty, GlobalConstants.AllActionName, GlobalConstants.ShareClassesControllerName);
        }
    }
}
