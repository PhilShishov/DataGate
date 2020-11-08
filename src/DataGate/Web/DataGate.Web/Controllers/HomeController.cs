namespace DataGate.Web.Controllers
{
    using System.Diagnostics;

    using DataGate.Common;
    using DataGate.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(EndpointsConstants.Slash + EndpointsConstants.RouteUserPanel);
            }

            return this.View();
        }

        public IActionResult AccessDenied() => this.View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
        this.View(new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? 
            this.HttpContext.TraceIdentifier 
        });
        
    }
}
