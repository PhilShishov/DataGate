namespace DataGate.Web.Tests
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public WebTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/home/index")]
        [InlineData("/account/login")]
        [InlineData("/account/logout")]
        [InlineData("/account/forgot-password")]
        [InlineData("/account/confirmation")]
        [InlineData("/account/access-denied")]
        public async Task GetRequests_WithValidUrl_ShoudReturnSuccessStatusCodeWithTitle(string url)
        {
            var client = server.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>", responseContent);
        }

        [Theory]
        [InlineData("/account/email")]
        [InlineData("/account/change-password")]
        [InlineData("/account/personal-data")]
        [InlineData("/userpanel")]
        [InlineData("/funds")]
        [InlineData("/subfunds")]
        [InlineData("/shareclasses")]
        [InlineData("/sc/new")]
        [InlineData("/sc/edit/1/2020-11-09")]
        [InlineData("/reports/Fund/aum")]
        [InlineData("/reports/SubFund/aum")]
        [InlineData("/agreements/Fund")]
        [InlineData("/Admin/Admin/ViewUsers")]
        [InlineData("/Admin/Admin/CreateUser")]
        public async Task AccessPrivatePage_WithUnauthorizedUser_ShoudRedirectToLoginPage(string url)
        {
            var client = server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            string expectedUrl = $"/Account/Login?ReturnUrl={WebUtility.UrlEncode(url)}";
            Assert.Contains(expectedUrl, response.Headers.Location.ToString());
        }
    }
}
