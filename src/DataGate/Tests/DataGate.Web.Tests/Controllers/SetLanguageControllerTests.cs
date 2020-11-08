namespace DataGate.Web.Tests.Controllers
{

    using DataGate.Common;
    using DataGate.Web.Controllers;
    using Microsoft.AspNetCore.Localization;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class SetLanguageControllerTests
    {
        [Theory]
        [InlineData("/home/index")]
        [InlineData("/account/login")]
        [InlineData("/")]
        public void SetLanguage_WithPassedCultureAndReturnUrl_ShoudldSetCultureCookieToResponseAndRedirectToProvidedReturnUrl(string url) =>
            MyController<SetLanguageController>
            .Instance()
            .Calling(c => c.SetLanguage(GlobalConstants.DefaultCultureInfo, url))
            .ShouldHave()
            .HttpResponse(response => response
                .ContainingCookie(CookieRequestCultureProvider.DefaultCookieName))
            .AndAlso()
            .ShouldReturn()
            .Redirect(url);
    }
}
