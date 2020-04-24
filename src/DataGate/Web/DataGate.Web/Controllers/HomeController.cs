namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View("Index");
        }

        //public IActionResult Error()
        //{
        //    return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        //}
    }
}