namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class MvcConfiguration
    {
        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services
               .AddMvcCore()
               .AddViewLocalization()
               .AddMvcLocalization();

            // .AddRazorPagesOptions(options =>
            // {
            //    options.AllowAreas = true;
            //    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            //    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            // });

            return services;
        }
    }
}
