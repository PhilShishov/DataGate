﻿namespace DataGate.Web.Configuration
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public static class CookieConfiguration
    {
        public static IServiceCollection ConfigureCookies(this IServiceCollection services)
        {
            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                })
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.Secure = CookieSecurePolicy.Always;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                    options.ConsentCookie.Name = ".AspNetCore.ConsentCookie";
                });

            return services;
        }
    }
}
