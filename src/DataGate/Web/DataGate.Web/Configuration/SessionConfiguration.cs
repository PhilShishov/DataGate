namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class SessionConfiguration
    {
        private const int SessionIdleTimeout = 2;

        public static IServiceCollection ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(SessionIdleTimeout);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
    }
}
