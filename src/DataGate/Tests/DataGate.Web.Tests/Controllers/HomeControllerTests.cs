// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.Controllers
{
    using DataGate.Web.Controllers;

    using MyTested.AspNetCore.Mvc;

    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void AccessDenied_ShouldReturnView() =>
            MyController<HomeController>
            .Instance()
            .Calling(c => c.AccessDenied())
            .ShouldReturn()
            .View();
    }
}
