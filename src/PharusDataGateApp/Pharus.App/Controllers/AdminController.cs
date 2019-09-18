namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Data;
    using Pharus.Domain;
    using Pharus.App.ViewModels.Users;

    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        private readonly RoleManager<PharusUserRole> _roleManager;
        private readonly UserManager<PharusUser> _userManager;
        private readonly ILogger<UserCreateBindingModel> _logger;
        private readonly PharusUsersDbContext context;

        public AdminController(
            UserManager<PharusUser> userManager,
            RoleManager<PharusUserRole> roleManager,
            ILogger<UserCreateBindingModel> logger, 
            PharusUsersDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
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
        public async Task<IActionResult> Create(UserCreateBindingModel bindingModel, string returnUrl = null)
        {
            returnUrl = "/Admin/Index";
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel ?? new UserCreateBindingModel());
            }

            var user = new PharusUser
            {
                UserName = bindingModel.Username,
                Email = bindingModel.Email
            };

            var userResult = await _userManager.CreateAsync(user, bindingModel.Password);

            var role = bindingModel.RoleType.ToString();
            var roleExist = await _roleManager.RoleExistsAsync(role);

            if (roleExist)
            {
                if (role == "Admin")
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else if (role == "Legal")
                {
                    await _userManager.AddToRoleAsync(user, "Legal");
                }
                else if (role == "Risk")
                {
                    await _userManager.AddToRoleAsync(user, "Risk");
                }
                else if (role == "Investment")
                {
                    await _userManager.AddToRoleAsync(user, "Investment");
                }
                else if (role == "Compliance")
                {
                    await _userManager.AddToRoleAsync(user, "Compliance");
                }
            }

            if (userResult.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                return LocalRedirect(returnUrl);
            }

            return this.Redirect(returnUrl);
        }
    }
}
