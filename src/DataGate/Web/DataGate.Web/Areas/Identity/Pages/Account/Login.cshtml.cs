namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using DataGate.Web.Resources;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private const string UserIndexUrl = "/userpanel";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SharedLocalizationService sharedLocalizer;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<LoginModel> logger;

        public LoginModel(
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager,
            SharedLocalizationService sharedLocalizer)
        {
            this.userManager = userManager;
            this.sharedLocalizer = sharedLocalizer;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                this.ModelState.AddModelError(string.Empty, this.ErrorMessage);
            }

            if (!this.signInManager.IsSignedIn(this.User))
            {
                // Clear the existing external cookie to ensure a clean login process
                await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                return this.Page();
            }

            return this.Redirect(UserIndexUrl);
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");

            if (this.ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                Microsoft.AspNetCore.Identity.SignInResult result = await this.signInManager
                    .PasswordSignInAsync(this.Input.Username, this.Input.Password, this.Input.RememberMe, lockoutOnFailure: false);
                var user = await this.userManager.FindByNameAsync(this.Input.Username);

                if (result.Succeeded)
                {
                    this.logger.LogInformation("User logged in.");

                    if (user == null)
                    {
                        return this.NotFound("Unable to load user for update last login.");
                    }

                    user.LastLoginTime = DateTimeOffset.UtcNow;
                    var lastLoginResult = await this.userManager.UpdateAsync(user);

                    if (!lastLoginResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Unexpected error occurred setting the last login date" +
                            $" ({lastLoginResult.ToString()}) for user with ID '{user.Id}'.");
                    }

                    if (await this.userManager.IsEmailConfirmedAsync(user) == false)
                    {
                        this.ErrorMessage = this.sharedLocalizer.GetHtmlString(ErrorMessages.EmailNotConfirmed);
                        this.ModelState.AddModelError(string.Empty, ErrorMessages.EmailNotConfirmed);
                        return this.Page();
                    }

                    return this.Redirect(EndpointsConstants.Slash + EndpointsConstants.RouteUserPanel);
                }

                if (await this.userManager.IsEmailConfirmedAsync(user) == false)
                {
                    this.ErrorMessage = this.sharedLocalizer.GetHtmlString(ErrorMessages.EmailNotConfirmed);
                    this.ModelState.AddModelError(string.Empty, ErrorMessages.EmailNotConfirmed);
                    return this.Page();
                }

                if (result.RequiresTwoFactor)
                {
                    return this.RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = this.Input.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    this.logger.LogWarning("User account locked out.");
                    return this.RedirectToPage("./Lockout");
                }
                else
                {
                    this.ErrorMessage = this.sharedLocalizer.GetHtmlString(ErrorMessages.InvalidLoginAttempt);
                    this.ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLoginAttempt);
                    return this.Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = ValidationMessages.FieldRequired)]
            public string Username { get; set; }

            [Required(ErrorMessage = ValidationMessages.FieldRequired)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }

            [GoogleReCaptchaValidation]
            public string RecaptchaValue { get; set; }
        }
    }
}
