namespace DataGate.Web.Configuration
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class ViewsConfiguration
    {
        public static IServiceCollection ConfigureViews(this IServiceCollection services)
        {
            services.AddControllersWithViews(
               options =>
               {
                   options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
               });
            services.AddRazorPages();

            return services;
        }
    }
}
