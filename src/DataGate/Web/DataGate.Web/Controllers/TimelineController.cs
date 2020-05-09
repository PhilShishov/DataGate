namespace DataGate.Web.Controllers
{
    using DataGate.Services.Data.Funds.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public class TimelineController : Controller
    {
        private readonly IFundSubEntitiesService fundService;

        public TimelineController(IFundSubEntitiesService fundService)
        {
            this.fundService = fundService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
