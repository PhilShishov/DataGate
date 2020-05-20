namespace DataGate.Web.Configuration
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    public static class SessionConfiguration
    {
        private const int SessionIdleTimeout = 2;

        public static IServiceCollection ConfigureSession(this IServiceCollection services)
        {
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
