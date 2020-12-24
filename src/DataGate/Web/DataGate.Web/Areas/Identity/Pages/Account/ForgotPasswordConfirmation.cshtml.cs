// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using DataGate.Data.Models.Users;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        private const string UserIndexUrl = "/User/Index";
        private readonly SignInManager<ApplicationUser> signInManager;

        public ForgotPasswordConfirmation(
            SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            if (!this.signInManager.IsSignedIn(this.User))
            {
                return this.Page();
            }

            return this.Redirect(UserIndexUrl);
        }
    }
}
