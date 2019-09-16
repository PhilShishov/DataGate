namespace Pharus.App.Areas.Identity.Pages.Account
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using Pharus.Data;
    using Pharus.Domain;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<PharusUser> _signInManager;
        private readonly RoleManager<PharusUserRole> _roleManager;
        private readonly UserManager<PharusUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly PharusUsersDbContext _context;

        public RegisterModel(
            UserManager<PharusUser> userManager,
            RoleManager<PharusUserRole> roleManager,
            SignInManager<PharusUser> signInManager,
            ILogger<RegisterModel> logger,
            PharusUsersDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string SelectedRole { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            Roles = _context
                .Roles
                .Select(r =>
                new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                });

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new PharusUser { UserName = Input.Username, Email = Input.Email };
                var userResult = await _userManager.CreateAsync(user, Input.Password);

                var roleResult = Input.SelectedRole.ToString();
                var roleExist = await _roleManager.RoleExistsAsync(roleResult);

                if (roleExist)
                {
                    //First create
                    //if (_userManager.Users.Count() <= 2)
                    //{
                    //    await _userManager.AddToRoleAsync(user, "Admin");
                    //}
                    if (roleResult == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else if (roleResult == "Legal")
                    {
                        await _userManager.AddToRoleAsync(user, "Legal");
                    }
                    else if (roleResult == "Risk")
                    {
                        await _userManager.AddToRoleAsync(user, "Risk");
                    }
                    else if (roleResult == "Investment")
                    {
                        await _userManager.AddToRoleAsync(user, "Investment");
                    }
                    else if (roleResult == "Compliance")
                    {
                        await _userManager.AddToRoleAsync(user, "Compliance");
                    }
                }

                if (userResult.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }    
}