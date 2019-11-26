namespace Pharus.App.Areas.Identity.Pages.Account
{
    using System;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using Pharus.Domain;

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<PharusUser> signInManager;
        private readonly UserManager<PharusUser> userManager;
        private readonly ILogger<LoginModel> logger;

        public LoginModel(
            SignInManager<PharusUser> signInManager,
            UserManager<PharusUser> userManager,
            ILogger<LoginModel> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                this.ModelState.AddModelError(string.Empty, this.ErrorMessage);
            }

            returnUrl = returnUrl ?? this.Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            this.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (this.ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await this.signInManager.PasswordSignInAsync(this.Input.Username, this.Input.Password, this.Input.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    this.logger.LogInformation("User logged in.");

                    var user = await this.userManager.FindByNameAsync(this.Input.Username);

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

                    var roles = await this.userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        returnUrl = "/Admin/Index";
                    }
                    else
                    {
                        returnUrl = "/Home/Index";
                    }

                    return this.Redirect(returnUrl);
                }

                // TODO UnsuccessfulLogin view
                // else
                // {
                //    returnUrl = "/Identity/Account/UnsuccessfulLogin";
                //    return Redirect(returnUrl);
                // }
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return this.Page();
            }

            return this.Page();
        }
    }
}