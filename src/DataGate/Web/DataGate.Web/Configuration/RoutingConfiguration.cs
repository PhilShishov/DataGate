namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class RoutingConfiguration
    {
        public static IServiceCollection ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            return services;
        }
    }
}
