namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class AuthorizationConfiguration
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                });

            return services;
        }
    }
}
