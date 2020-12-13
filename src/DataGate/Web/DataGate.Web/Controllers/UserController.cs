namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using DataGate.Services.Data.Recent;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Web.ViewModels.Users;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IRecentService serviceRecent;
        private readonly IShareClassService service;

        public UserController(
            IRecentService serviceRecent,
            IShareClassService service)
        {
            this.serviceRecent = serviceRecent;
            this.service = service;
        }

        [Route("userpanel")]
        public IActionResult Index()
        {
            var viewModel = new UserPanelViewModel
            {
                ShareClasses = this.service.ByDate(),
                RecentlyViewed = this.serviceRecent.ByUserId(this.User),
            };

           return this.View(viewModel);
        }
    }
}
