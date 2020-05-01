namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class LegalController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult Copyright()
        {
            return this.View();
        }

        public IActionResult Cookie()
        {
            return this.View();
        }

        public IActionResult UserAgreement()
        {
            return this.View();
        }
    }
}
