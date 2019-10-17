namespace Pharus.App.Controllers
{
    using System.Linq;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;

    using Pharus.Domain;
    using Pharus.Domain.Users;
    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Users;
    using Pharus.App.Models.BindingModels.Users;

    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        private readonly IRolesService rolesService;
        private readonly IUsersService usersService;
        private readonly RoleManager<PharusRole> _roleManager;
        private readonly UserManager<PharusUser> _userManager;
        private readonly ILogger<UserCreateBindingModel> _logger;

        public AdminController(
            IRolesService rolesService,
            IUsersService usersService,
            UserManager<PharusUser> userManager,
            RoleManager<PharusRole> roleManager,
            ILogger<UserCreateBindingModel> logger)
        {
            this.rolesService = rolesService;
            this.usersService = usersService;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
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
        public IActionResult ViewUser()
        {
            List<UserViewModel> usersView = this.usersService.GetAllUserRoles()
                .Select(user => new UserViewModel
                {
                    Username = user.UserName,
                    Role = user.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault(),
                    LastLogin = user.LastLoginTime?.ToString("dd.MM.yyyy HH:mm", 
                        CultureInfo.InvariantCulture)
                })
                .ToList();

            return View(usersView);
        }

        [HttpGet("/Admin/EditUserPanel")]
        public IActionResult EditUserPanel()
        {
            return this.View();
        }

        [HttpGet("Admin/EditUser")]
        public IActionResult EditUser(string username)
        {
            EditUserBindingModel editUserModel = this.usersService
                .GetAllUserRoles()
                .Where(u => u.UserName == username)
                .Select(u => new EditUserBindingModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Email = u.Email,
                    RoleType = u.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()
                })
                .FirstOrDefault();

            return this.View(editUserModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserBindingModel model, string returnUrl = null)
        {
            returnUrl = "/Admin/Index";

            if (!ModelState.IsValid)
            {
                return View(model ?? new EditUserBindingModel());
            }

            var user = this.usersService.GetAllUserRoles()
                .Where(u => u.UserName == model.Id)
                .FirstOrDefault();

            if (HttpContext.Request.Form.ContainsKey("save_button"))
            {
                user.UserName = model.Username;
                user.Email = model.Email;

                var newRole = model.RoleType;
                var oldRole = user.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault();
                if (this.rolesService.GetRole(newRole) != null)
                {
                    if (newRole != oldRole)
                    {
                        await this._userManager.RemoveFromRoleAsync(user, oldRole);
                        await this._userManager.AddToRoleAsync(user, newRole);
                    }
                }

                PasswordHasher<PharusUser> hasher = new PasswordHasher<PharusUser>();

                if (user.PasswordHash != model.PasswordHash && model.PasswordHash != null)
                {
                    var newPassword = hasher.HashPassword(user, model.PasswordHash);
                    user.PasswordHash = newPassword;
                }

                var resultUser = await _userManager.UpdateAsync(user);

                if (resultUser.Succeeded)
                {
                    _logger.LogInformation("User updated.");

                    return LocalRedirect(returnUrl);
                }
            }

            else if (HttpContext.Request.Form.ContainsKey("delete_button"))
            {
                var result = await this._userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User deleted.");

                    return LocalRedirect(returnUrl);
                }
            }

            return this.RedirectToPage(returnUrl);
        }

        #region Helpers

        private async Task AssignRoleToUser(UserCreateBindingModel bindingModel, PharusUser user)
        {
            var role = bindingModel.RoleType;
            var roleExist = await _roleManager.RoleExistsAsync(role);

            if (roleExist)
            {
                if (role == "Admin" && _userManager.Users.Count() == 2)
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