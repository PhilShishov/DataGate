namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ConfirmEmailModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
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

            this.TempData[GlobalConstants.InfoKey] = InfoMessages.SuccessfullyConfirmedEmail;
            return this.Redirect("/");
        }
    }
}
