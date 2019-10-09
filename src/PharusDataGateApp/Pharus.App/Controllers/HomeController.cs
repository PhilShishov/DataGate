
namespace Pharus.App.Controllers
{
    using System;
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    
    using Pharus.App.ViewModels;

    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}