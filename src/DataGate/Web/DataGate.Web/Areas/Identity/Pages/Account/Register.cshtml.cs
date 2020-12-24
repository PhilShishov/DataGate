// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
                return this.Redirect(EndpointsConstants.Slash + EndpointsConstants.FundsController.ToLower());
            }

            return this.Redirect(EndpointsConstants.Slash + EndpointsConstants.FundsController.ToLower());
        }

        public IActionResult OnPost(string returnUrl = null)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(EndpointsConstants.Slash + EndpointsConstants.FundsController.ToLower());
            }

            return this.Redirect(EndpointsConstants.Slash + EndpointsConstants.FundsController.ToLower());
        }
    }
}
