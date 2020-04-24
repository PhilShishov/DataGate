namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using DataGate.Domain.Models.Users;

    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<PharusUser> signInManager;
        private readonly ILogger<LogoutModel> logger;

        public LogoutModel(SignInManager<PharusUser> signInManager, ILogger<LogoutModel> logger)
        {
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            if (this.User?.Identity.IsAuthenticated == true)
            {
                await this.signInManager.SignOutAsync();
                this.logger.LogInformation("User logged out.");
                return this.RedirectToPage();
            }

            return this.Page();
        }
    }
}