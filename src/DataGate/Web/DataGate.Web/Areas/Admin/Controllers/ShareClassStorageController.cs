namespace DataGate.Web.Areas.Admin.Controllers
{
    using DataGate.Services.Data.Storage.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ShareClassStorageController : Controller
    {
        private readonly IShareClassStorageService service;

        public ShareClassStorageController(
                        IShareClassStorageService fundService
                        )
        {
            this.service = fundService;
          
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
