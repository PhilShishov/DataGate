// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    using DataGate.Common;
    using DataGate.Web.Resources;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class LocalizationConfiguration
    {
        private const string ResourcesFolderName = "Resources";

        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            services.AddSingleton<SharedLocalizationService>();
            services.AddLocalization(options => options.ResourcesPath = ResourcesFolderName);

            services.Configure<RequestLocalizationOptions>(
               options =>
               {
                   var supportedCultures = new List<CultureInfo>
                   {
                        new CultureInfo(GlobalConstants.DefaultCultureInfo),
                        new CultureInfo(GlobalConstants.ItalianCultureInfo),
                   };
                   options.DefaultRequestCulture = new RequestCulture(culture: GlobalConstants.DefaultCultureInfo, uiCulture: GlobalConstants.DefaultCultureInfo);
                   options.SupportedCultures = supportedCultures;
                   options.SupportedUICultures = supportedCultures;
                   options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
               });

            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                });

            return services;
        }

        public static IApplicationBuilder UserLocalization(this IApplicationBuilder app)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            return app;
        }
    }
}
