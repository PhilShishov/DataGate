namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
