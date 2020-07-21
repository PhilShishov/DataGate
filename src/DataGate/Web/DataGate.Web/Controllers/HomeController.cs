namespace DataGate.Web.Controllers
{
    using System;
    using System.Diagnostics;

    using DataGate.Common;
    using DataGate.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(GlobalConstants.UserPanelUrl);
            }

            return this.View();
        }

        public IActionResult AccessDenied() => this.View();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
