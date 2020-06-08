namespace DataGate.Web.Areas.Admin.Controllers
{
    using DataGate.Services.Data.Storage.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ShareClassStorageController : Controller
    {
        private readonly IShareClassStorageService service;
        private readonly IShareClassSelectListService serviceSelect;

        public ShareClassStorageController(
                        IShareClassStorageService fundService,
                        IShareClassSelectListService fundServiceSelect)
        {
            this.service = fundService;
            this.serviceSelect = fundServiceSelect;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
