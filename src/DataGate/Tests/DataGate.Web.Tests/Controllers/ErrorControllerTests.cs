// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.Controllers
{

    using DataGate.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class ErrorControllerTests
    {

        [Fact]
        public void Error_ShouldReturnViewAndShouldHaveResponceCacheAttribute() =>
            MyController<ErrorController>
            .Instance()
            .Calling(c => c.Error())
            .ShouldHave()
            .ActionAttributes(attributes => attributes
                .CachingResponse(responseCache => responseCache
                    .WithDuration(0)
                    .WithLocation(ResponseCacheLocation.None)
                    .WithNoStore(true)))
            .AndAlso()
            .ShouldReturn()
            .View();
    }
}