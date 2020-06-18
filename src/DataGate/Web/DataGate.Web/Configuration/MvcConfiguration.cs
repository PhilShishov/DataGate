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
            return services;
        }
    }
}
