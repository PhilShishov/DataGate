namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : BaseController
    {
        [Route("userpanel")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
