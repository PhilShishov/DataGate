// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class SettingsConfiguration
    {
        public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            return services;
        }
    }
}
