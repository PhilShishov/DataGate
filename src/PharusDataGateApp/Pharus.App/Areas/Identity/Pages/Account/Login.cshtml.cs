﻿
namespace Pharus.App.Areas.Identity.Pages.Account
{
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
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<PharusUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
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
            returnUrl = "/Home/Index";
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return Redirect(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}