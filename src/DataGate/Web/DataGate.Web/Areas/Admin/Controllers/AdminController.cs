namespace DataGate.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Settings;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Messaging;
    using DataGate.Web.Controllers;
    using DataGate.Web.InputModels.Users;
    using DataGate.Web.Resources;
    using DataGate.Web.ViewModels.Users;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    [Area(EndpointsConstants.AdminAreaName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        private const string EmailConfirmationUrl = "/Account/ConfirmEmail";
        private const string ViewUsersUrl = "/Admin/Admin/ViewUsers";
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<AdminController> logger;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;
        private readonly SharedLocalizationService sharedLocalizer;


        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IEmailSender emailSender,
            SharedLocalizationService sharedLocalizer,
            ILogger<AdminController> logger,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this.sharedLocalizer = sharedLocalizer;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<IActionResult> ViewUsers()
        {
            List<UserViewModel> usersViewList = new List<UserViewModel>();

            var users = this.userManager.Users
                .OrderByDescending(u => u.LastLoginTime)
                .ToList();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                var userView = new UserViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = roles,
                    LastLogin = user.LastLoginTime,
                };

                usersViewList.Add(userView);
            }

            return this.View(usersViewList);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            this.ViewData["Roles"] = this.roleManager.Roles.ToList();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(
                     [Bind("Username", "Email", "Password", "ConfirmPassword", "RoleType", "RecaptchaValue")]
                     CreateUserInputModel inputModel)
        {
            string returnUrl = ViewUsersUrl;
            if (!this.ModelState.IsValid)
            {
                this.ViewData["Roles"] = this.roleManager.Roles.ToList();
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
                await this.AssignRoleToUser(inputModel, user);

                // Upon creation send email confirmation to new user
                string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                string callbackUrl = this.Url.Page(
                    EmailConfirmationUrl,
                    pageHandler: null,
                    values: new { area = "Identity", userId = user.Id, code },
                    protocol: this.Request.Scheme);

                string emailMessage = string.Format(GlobalConstants.EmailConfirmationMessage, HtmlEncoder.Default.Encode(callbackUrl));
                await this.emailSender.SendEmailAsync(
                    this.configuration.GetValue<string>($"{AppSettingsSections.EmailSection}:{EmailOptions.Address}"),
                    this.configuration.GetValue<string>($"{AppSettingsSections.EmailSection}:{EmailOptions.Sender}"),
                    inputModel.Email,
                    GlobalConstants.ConfirmEmailSubject,
                    emailMessage);

                string infoMessage = string.Format(this.sharedLocalizer.GetHtmlString(InfoMessages.AddUser), user.UserName, inputModel.RoleType);

                return this.ShowInfoLocal(infoMessage, returnUrl);
            }

            this.AddErrors(result);

            return this.ShowErrorLocal(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulCreate), returnUrl);
        }

        [HttpGet("/Admin/Admin/EditUser/{id}")]
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
        public async Task<IActionResult> EditUser(
                     [Bind("Id", "Username", "Email", "RoleType", "PasswordHash", "ConfirmPassword", "RecaptchaValue")]
                     EditUserInputModel inputModel, string returnUrl = null)
        {
            returnUrl = ViewUsersUrl;

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel ?? new EditUserInputModel());
            }

            var user = await this.userManager.FindByIdAsync(inputModel.Id);

            if (user != null)
            {
                var roles = await this.userManager.GetRolesAsync(user);

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

                    string infoMessage = string.Format(this.sharedLocalizer.GetHtmlString(InfoMessages.UpdateUser), user.UserName);

                    return this.ShowInfoLocal(infoMessage, returnUrl);
                }

                this.AddErrors(resultUser);
            }

            return this.ShowErrorLocal(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate), returnUrl);
        }

        [HttpGet("/Admin/Admin/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var roles = await this.userManager.GetRolesAsync(user);

            DeleteUserInputModel deleteUserModel = new DeleteUserInputModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleType = roles.FirstOrDefault(),
            };

            return this.View(deleteUserModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(
              [Bind("Id", "RecaptchaValue")]
              DeleteUserInputModel inputModel, string returnUrl = null)
        {
            returnUrl = ViewUsersUrl;

            var user = await this.userManager.FindByIdAsync(inputModel.Id);

            if (user != null)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                await this.userManager.RemoveFromRoleAsync(user, roles.FirstOrDefault());
                var result = await this.userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("User deleted.");

                    string infoMessage = string.Format(this.sharedLocalizer.GetHtmlString(InfoMessages.RemoveUser), user.UserName);

                    return this.ShowInfoLocal(infoMessage, returnUrl);
                }

                this.AddErrors(result);
            }

            return this.ShowErrorLocal(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulDelete), returnUrl);
        }

        private async Task AssignRoleToUser(CreateUserInputModel inputModel, ApplicationUser user)
        {
            var role = inputModel.RoleType;
            var roleExist = await this.roleManager.RoleExistsAsync(role);
            var admins = this.userManager.GetUsersInRoleAsync(GlobalConstants.AdministratorRoleName).Result;

            if (roleExist)
            {
                if (role == GlobalConstants.AdministratorRoleName /*&& admins.Count <= GlobalConstants.MaxAdminCount*/)
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
                else if (role == GlobalConstants.GuestRoleName)
                {
                    await this.userManager.AddToRoleAsync(user, GlobalConstants.GuestRoleName);
                }
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error.Code.Contains("Password"))
                {
                    ViewData["Password"] = ViewData["Password"] + error.Description;
                }
                else
                {
                    this.ModelState.AddModelError(error.Code, error.Description);
                }

            }
        }
    }
}
