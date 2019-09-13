
namespace Pharus.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}