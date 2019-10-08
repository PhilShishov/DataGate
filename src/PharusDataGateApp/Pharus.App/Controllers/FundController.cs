namespace Pharus.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class FundController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}