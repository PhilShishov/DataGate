namespace DataGate.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using DataGate.Web.Controllers;
    using DataGate.Web.InputModels.Users;
    using DataGate.Web.ViewModels.Users;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [ValidateAntiForgeryToken]
    [Area("Administration")]
    public class AdminController : BaseController
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<UserCreateInputModel> logger;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ILogger<UserCreateInputModel> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            this.ViewData["Roles"] = this.roleManager.Roles.ToList();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateInputModel inputModel)
        {
            string returnUrl = "/Admin/ViewUsers";
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel ?? new UserCreateInputModel());
            }

            var user = new ApplicationUser
            {
                UserName = inputModel.Username,
                Email = inputModel.Email,
            };

            var result = await this.userManager.CreateAsync(user, inputModel.Password);

            if (result.Succeeded)
            {
                this.logger.LogInformation("User created a new account with password.");

                await this.AssignRoleToUser(inputModel, user);
                return this.LocalRedirect(returnUrl);
            }

            this.AddErrors(result);

            return this.RedirectToPage("/Admin/CreateUser");
        }

        public async Task<IActionResult> ViewUsers()
        {
            List<UserViewModel> usersViewList = new List<UserViewModel>();

            var users = this.userManager.Users.ToList();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                var userView = new UserViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = roles,
                    LastLogin = user.LastLoginTime?.ToString(
                            GlobalConstants.LastLoginTimeDisplay,
                            CultureInfo.InvariantCulture),
                };

                usersViewList.Add(userView);
            }

            return this.View(usersViewList);
        }

        [HttpGet("Admin/EditUser/{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var roles = await this.userManager.GetRolesAsync(user);

            EditUserInputModel editUserModel = new EditUserInputModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleType = roles.FirstOrDefault(),
            };

            return this.View(editUserModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserInputModel inputModel, string returnUrl = null)
        {
            returnUrl = "/Admin/Index";

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel ?? new EditUserInputModel());
            }

            var user = await this.userManager.FindByIdAsync(inputModel.Id);
            var roles = await this.userManager.GetRolesAsync(user);

            // TODO case with 2 or more roles for same user
            if (this.HttpContext.Request.Form.ContainsKey("save_button"))
            {
                user.UserName = inputModel.Username;
                user.Email = inputModel.Email;

                var newRole = inputModel.RoleType;
                var oldRole = roles.FirstOrDefault();

                if (await this.roleManager.RoleExistsAsync(newRole))
                {
                    if (newRole != oldRole)
                    {
                        await this.userManager.RemoveFromRoleAsync(user, oldRole);
                        await this.userManager.AddToRoleAsync(user, newRole);
                    }
                }

                PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

                if (user.PasswordHash != inputModel.PasswordHash && inputModel.PasswordHash != null)
                {
                    var newPassword = hasher.HashPassword(user, inputModel.PasswordHash);
                    user.PasswordHash = newPassword;
                }

                var resultUser = await this.userManager.UpdateAsync(user);

                if (resultUser.Succeeded)
                {
                    this.logger.LogInformation("User updated.");

                    return this.LocalRedirect(returnUrl);
                }
            }
            else if (this.HttpContext.Request.Form.ContainsKey("delete_button"))
            {
                var result = await this.userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("User deleted.");

                    return this.LocalRedirect(returnUrl);
                }
            }

            return this.RedirectToPage(returnUrl);
        }

        private async Task AssignRoleToUser(UserCreateInputModel inputModel, ApplicationUser user)
        {
            var role = inputModel.RoleType;
            var roleExist = await this.roleManager.RoleExistsAsync(role);
            var admins = this.userManager.GetUsersInRoleAsync(GlobalConstants.AdministratorRoleName).Result;

            if (roleExist)
            {
                if (role == GlobalConstants.AdministratorRoleName && admins.Count <= GlobalConstants.MaxAdminCount)
                {
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
                else if (role == GlobalConstants.LegalRoleName)
                {
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.LegalRoleName);
                }
                else if (role == GlobalConstants.RiskRoleName)
                {
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.RiskRoleName);
                }
                else if (role == GlobalConstants.InvestmentRoleName)
                {
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.InvestmentRoleName);
                }
                else if (role == GlobalConstants.ComplianceRoleName)
                {
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.ComplianceRoleName);
                }
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
