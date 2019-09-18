namespace Pharus.App.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.App.ViewModels.Users;

    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        private readonly PharusUsersDbContext context;

        public AdminController(PharusUsersDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            this.ViewData["Roles"] = this.context.Roles.ToList();

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateBindingModel bindingModel)
        {
            return this.View();
        }
    }
}
