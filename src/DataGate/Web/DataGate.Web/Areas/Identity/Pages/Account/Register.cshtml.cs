namespace DataGate.Web.Areas.Identity.Pages.Account
{
    using DataGate.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [Authorize]
    public class RegisterModel : PageModel
    {
        public RegisterModel()
        {
        }

        public IActionResult OnGet(string returnUrl = null)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(GlobalConstants.FundAllUrl);
            }

            return this.Redirect(GlobalConstants.FundAllUrl);
        }

        public IActionResult OnPost(string returnUrl = null)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(GlobalConstants.FundAllUrl);
            }

            return this.Redirect(GlobalConstants.FundAllUrl);
        }
    }
}
