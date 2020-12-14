namespace DataGate.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc; 

    using DataGate.Web.ViewModels;

    public class HomeController : BaseController
    {
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
