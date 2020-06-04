namespace DataGate.Web.Configuration
{
    using System.Globalization;

    using DataGate.Common;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.Extensions.DependencyInjection;

    public static class LocalizationConfiguration
    {
        private const string ResourcesFolderName = "Resources";

        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddViewLocalization()
                .AddMvcLocalization();
            services.AddLocalization(options => options.ResourcesPath = ResourcesFolderName);
            return services;
        }

        public static IApplicationBuilder UserLocalization(this IApplicationBuilder app)
        {
            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo(GlobalConstants.ItalianCultureInfo),
                new CultureInfo(GlobalConstants.CurrentCultureInfo),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(GlobalConstants.CurrentCultureInfo),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });

            return app;
        }

        public static void SetDefaultCulture()
        {
            var cultureInfo = new CultureInfo(GlobalConstants.CurrentCultureInfo);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
