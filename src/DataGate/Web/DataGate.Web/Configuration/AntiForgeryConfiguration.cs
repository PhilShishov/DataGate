namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class AntiForgeryConfiguration
    {
        public static IServiceCollection ConfigureAntiForgery(this IServiceCollection services)
        {
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            return services;
        }
    }
}
