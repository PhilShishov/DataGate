// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.Administration.Controllers
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Settings;
    using DataGate.Services.Data.Users;
    using DataGate.Services.Messaging;
    using DataGate.Services.Notifications.Contracts;
    using DataGate.Web.Controllers;
    using DataGate.Web.Hubs.Contracts;
    using DataGate.Web.InputModels.Users;
    using DataGate.Web.Resources;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Area(EndpointsConstants.AdminAreaName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        private const string EmailConfirmationUrl = "/Account/ConfirmEmail";
        private const string ViewUsersUrl = "/Admin/Admin/All";

        private readonly IUserService userService;
        private readonly IHubNotificationHelper notificationHelper;
        private readonly INotificationService notificationService;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;
        private readonly SharedLocalizationService sharedLocalizer;

        public AdminController(
            IUserService userService,
            IHubNotificationHelper notificationHelper,
            INotificationService notificationService,
            IEmailSender emailSender,
            SharedLocalizationService sharedLocalizer,
            IConfiguration configuration)
        {
            this.userService = userService;
            this.notificationHelper = notificationHelper;
            this.notificationService = notificationService;
            this.emailSender = emailSender;
            this.sharedLocalizer = sharedLocalizer;
            this.configuration = configuration;
        }

        public async Task<IActionResult> All()
            => this.View(await this.userService.All());

        public IActionResult Create()
        {
            this.ViewData["Roles"] = this.userService.Roles();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                     [Bind("Username", "Email", "Password", 
                           "ConfirmPassword", "RoleType", "RecaptchaValue")]
                            CreateUserInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["Roles"] = this.userService.Roles();
                return this.View(input ?? new CreateUserInputModel());
            }

            var result = await this.userService.Create(input);

            if (!result.Succeeded)
            {
                this.AddErrors(result);
                return this.ShowErrorLocal(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulCreate), ViewUsersUrl);
            }

            var user = await this.userService.ByUsername(input.Username);
            string code = await this.userService.GenerateEmailToken(user);
            string callbackUrl = this.Url.Page(
                   EmailConfirmationUrl,
                   pageHandler: null,
                   values: new { area = "Identity", userId = user.Id, code },
                   protocol: this.Request.Scheme);

            //Upon creation send email confirmation to new user
            string emailMessage = string.Format(GlobalConstants.EmailConfirmationMessage, user.UserName, HtmlEncoder.Default.Encode(callbackUrl));
            await this.emailSender.SendEmailAsync(
                this.configuration.GetValue<string>($"{AppSettingsSections.EmailSection}:{EmailOptions.Address}"),
                this.configuration.GetValue<string>($"{AppSettingsSections.EmailSection}:{EmailOptions.Sender}"),
                user.Email,
                GlobalConstants.ConfirmEmailSubject,
                emailMessage);

            await SendNotification(user.UserName, InfoMessages.CreateUserNotification);

            string infoMessage = string.Format(this.sharedLocalizer
                .GetHtmlString(InfoMessages.AddUser),
                user.UserName,
                input.RoleType);

            return this.ShowInfoLocal(infoMessage, ViewUsersUrl);
        }

        public async Task<IActionResult> Edit(string id)
            => this.View(await this.userService.ByIdEdit(id));

        [HttpPost]
        public async Task<IActionResult> Edit(
                     [Bind("Id", "Username", "Email", "RoleType",
                           "PasswordHash", "ConfirmPassword", "RecaptchaValue")]
                            EditUserInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input ?? new EditUserInputModel());
            }

            var result = await this.userService.Edit(input);

            if (result.Succeeded)
            {
                await SendNotification(input.Username, InfoMessages.EditUserNotification);
                string infoMessage = string.Format(this.sharedLocalizer.GetHtmlString(InfoMessages.UpdateUser), input.Username);
                return this.ShowInfoLocal(infoMessage, ViewUsersUrl);
            }

            this.AddErrors(result);
            return this.ShowErrorLocal(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulUpdate), ViewUsersUrl);
        }

        public async Task<IActionResult> Delete(string id)
             => this.View(await this.userService.ByIdDelete(id));

        [HttpPost]
        public async Task<IActionResult> Delete(
              [Bind("Id", "Username", "RecaptchaValue")]
                     DeleteUserInputModel input)
        {
            var result = await this.userService.Delete(input);

            if (result.Succeeded)
            {
                await SendNotification(input.Username, InfoMessages.EditUserNotification);
                string infoMessage = string.Format(this.sharedLocalizer.GetHtmlString(InfoMessages.RemoveUser), input.Username);
                return this.ShowInfoLocal(infoMessage, ViewUsersUrl);
            }

            this.AddErrors(result);
            return this.ShowErrorLocal(this.sharedLocalizer.GetHtmlString(ErrorMessages.UnsuccessfulDelete), ViewUsersUrl);
        }

        private async Task SendNotification(string username, string message)
        {
            var notifMessage = string.Format(message, username);
            await this.notificationService.Add(this.User, notifMessage, ViewUsersUrl);

            int count = await this.notificationService.Count(this.User);
            await this.notificationHelper.SendToAll(count);
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
