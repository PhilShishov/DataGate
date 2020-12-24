// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models.Enums;
    using DataGate.Data.Models.Users;
    using DataGate.Web.Resources;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SharedLocalizationService sharedLocalizer;

        public ConfirmEmailModel(
            UserManager<ApplicationUser> userManager,
            SharedLocalizationService sharedLocalizer)
        {
            this.userManager = userManager;
            this.sharedLocalizer = sharedLocalizer;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return this.Redirect("/User/Index");
            }

            ApplicationUser user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException($"Unable to load user with ID '{userId}'.");
            }

            IdentityResult result = await this.userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
            }

            var notificationType = NotificationType.success;
            var notificationTypeUpper = notificationType.ToString().ToUpper();
            string message = this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfullyConfirmedEmail);

            string notification = string.Format(GlobalConstants.SweetAlertScript, notificationTypeUpper, message, notificationType);

            this.TempData[GlobalConstants.SweetAlertKey] = notification;
            return this.Redirect("./Login");
        }
    }
}
