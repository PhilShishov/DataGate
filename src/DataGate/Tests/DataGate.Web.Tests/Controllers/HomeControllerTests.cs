namespace DataGate.Web.Tests.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using DataGate.Web.Controllers;

    public class HomeControllerTests
    {
        [Fact]
        public void AccessDenied_ShouldReturnView() =>
            MyController<HomeController>
            .Instance()
            .Calling(c => c.AccessDenied())
            .ShouldReturn()
            .View();

        [Fact]
        public void Error_ShouldReturnViewAndShouldHaveResponceCacheAttribute() =>
            MyController<HomeController>
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
