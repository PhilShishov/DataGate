namespace Pharus.App.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Domain;
    using Pharus.App.ViewModels.Users;
    using Pharus.Services.Contracts;

    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        private readonly IRolesService rolesService;
        private readonly RoleManager<PharusUserRole> _roleManager;
        private readonly UserManager<PharusUser> _userManager;
        private readonly ILogger<UserCreateBindingModel> _logger;

        public AdminController(
            IRolesService rolesService,
            UserManager<PharusUser> userManager,
            RoleManager<PharusUserRole> roleManager,
            ILogger<UserCreateBindingModel> logger)
        {
            this.rolesService = rolesService;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult CreateUser()
        {
            this.ViewData["Roles"] = this.rolesService.GetAllRoles();

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserCreateBindingModel bindingModel, string returnUrl = null)
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

            var result = await _userManager.CreateAsync(user, bindingModel.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                //Assign role to new user
                await AssignRoleToUser(bindingModel, user);
                return LocalRedirect(returnUrl);
            }

            AddErrors(result);

            return this.RedirectToPage("/Admin/CreateUser");
        }


        #region Helpers
        private async Task AssignRoleToUser(UserCreateBindingModel bindingModel, PharusUser user)
        {
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
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
