namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SearchController : Controller
    {
        public IActionResult Search(string searchTerm)
        {
            return this.View();
        }
    }
}
