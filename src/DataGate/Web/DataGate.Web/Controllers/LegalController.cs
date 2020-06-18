namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class LegalController : Controller
    {
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [Route("cookie")]
        public IActionResult Cookie()
        {
            return this.View();
        }

        [Route("conditions")]
        public IActionResult Conditions()
        {
            return this.View();
        }
    }
}
