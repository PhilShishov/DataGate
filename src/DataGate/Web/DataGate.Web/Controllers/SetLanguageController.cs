namespace DataGate.Web.Controllers
{
    using System;

    using DataGate.Common;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;

    public class SetLanguageController : Controller
    {
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            string cookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMonths(GlobalConstants.CultureCookieExpirationTimeInMonths),
            };

            this.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cookie, cookieOptions);
            return this.Redirect(returnUrl);
        }
    }
}
