// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Messaging;

    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private const string ForgotPasswordConfirmationUrl = "/Account/ForgotPasswordConfirmation";
        private const string ResetPasswordUrl = "/Account/ResetPassword";
        private const string UserIndexUrl = "/User/Index";
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;

        public ForgotPasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult OnGet()
        {
            if (!this.signInManager.IsSignedIn(this.User))
            {
                return this.Page();
            }

            return this.Redirect(UserIndexUrl);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.FindByEmailAsync(this.Input.Email);
                if (user == null || !(await this.userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return this.RedirectToPage(ForgotPasswordConfirmationUrl);
                }

                string code = await this.userManager.GeneratePasswordResetTokenAsync(user);
                string callbackUrl = this.Url.Page(
                    ResetPasswordUrl,
                    pageHandler: null,
                    values: new { code },
                    protocol: this.Request.Scheme);

                string message = string.Format(GlobalConstants.PasswordResetMessage, HtmlEncoder.Default.Encode(callbackUrl));
                await this.emailSender.SendEmailAsync(
                    "philip.shishov@pharusmanco.lu",
                    "Pharus Management Lux S.A.",
                    this.Input.Email,
                    GlobalConstants.ResetPasswordEmailSubject,
                    message);

                return this.RedirectToPage(ForgotPasswordConfirmationUrl);
            }

            return this.Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = ValidationMessages.FieldRequired)]
            [EmailAddress]
            public string Email { get; set; }
        }
    }
}
