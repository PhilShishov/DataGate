namespace DataGate.Web.Controllers
{
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IShareClassService service;

        public UserController(IShareClassService service)
        {
            this.service = service;
        }

        [Route("userpanel")]
        public IActionResult Index()
        {
            var viewModel = new UserPanelViewModel
            {
               ShareClasses = this.service.ByDate(),
            };

           return this.View(viewModel);
        }
    }
}
