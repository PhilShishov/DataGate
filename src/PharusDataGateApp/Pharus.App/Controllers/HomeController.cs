namespace Pharus.App.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using Pharus.App.Models.ViewModels;

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