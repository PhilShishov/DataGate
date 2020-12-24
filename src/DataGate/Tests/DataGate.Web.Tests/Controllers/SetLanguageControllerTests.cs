// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.Controllers
{
    using Xunit;
    using Microsoft.AspNetCore.Localization;
    using MyTested.AspNetCore.Mvc;

    using DataGate.Common;
    using DataGate.Web.Controllers;

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
