
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
        private readonly SignInManager<PharusUser> _signInManager;
        private readonly UserManager<PharusUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(
            SignInManager<PharusUser> signInManager,
            UserManager<PharusUser> userManager,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
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
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    var user = await _userManager.FindByNameAsync(Input.Username);

                    if (user == null)
                    {
                        return NotFound("Unable to load user for update last login.");
                    }

                    //Last Login Time
                    user.LastLoginTime = DateTimeOffset.UtcNow;
                    var lastLoginResult = await _userManager.UpdateAsync(user);

                    if (!lastLoginResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Unexpected error occurred setting the last login date" +
                            $" ({lastLoginResult.ToString()}) for user with ID '{user.Id}'.");
                    }

                    //Get roles user
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        returnUrl = "/Admin/Index";
                    }
                    else
                    { 
                        returnUrl = "/Home/Index";
                    }

                    return Redirect(returnUrl);
                }
                //TODO UnsuccessfulLogin view
                //else
                //{
                //    returnUrl = "/Identity/Account/UnsuccessfulLogin";
                //    return Redirect(returnUrl);
                //}
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}