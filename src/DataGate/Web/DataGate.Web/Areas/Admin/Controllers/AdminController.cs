namespace DataGate.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Messaging;
    using DataGate.Web.Controllers;
    using DataGate.Web.InputModels.Users;
    using DataGate.Web.ViewModels.Users;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Admin")]
    public class AdminController : BaseController
    {
        private const string EmailConfirmationUrl = "/Account/ConfirmEmail";
        private const string ViewUsersUrl = "/Administration/Admin/ViewUsers";
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<CreateUserInputModel> logger;
        private readonly IEmailSender emailSender;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IEmailSender emailSender,
            ILogger<CreateUserInputModel> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
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
        public async Task<IActionResult> CreateUser(CreateUserInputModel inputModel)
        {
            string returnUrl = ViewUsersUrl;
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel ?? new CreateUserInputModel());
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

                // Upon creation send email confirmation to new user
                string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                string callbackUrl = this.Url.Page(
                    EmailConfirmationUrl,
                    pageHandler: null,
                    values: new { userId = user.Id, code },
                    protocol: this.Request.Scheme);

                string message = string.Format(GlobalConstants.EmailConfirmationMessage, HtmlEncoder.Default.Encode(callbackUrl));
                await this.emailSender.SendEmailAsync("philip.shishov@pharusmanco.lu", "Philip Shishov", inputModel.Email, GlobalConstants.ConfirmEmailSubject, message);

                await this.AssignRoleToUser(inputModel, user);
                return this.LocalRedirect(returnUrl);
            }

            this.AddErrors(result);

            return this.View();
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

        [HttpGet("/Administration/Admin/EditUser/{id}")]
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
            returnUrl = ViewUsersUrl;

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
                await this.userManager.RemoveFromRoleAsync(user, roles.FirstOrDefault());
                var result = await this.userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("User deleted.");

                    return this.LocalRedirect(returnUrl);
                }
            }

            return this.View();
        }

        private async Task AssignRoleToUser(CreateUserInputModel inputModel, ApplicationUser user)
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
