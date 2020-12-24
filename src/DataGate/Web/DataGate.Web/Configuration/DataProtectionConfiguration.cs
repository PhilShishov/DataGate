// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using System.IO;
    using DataGate.Common;
    using DataGate.Common.Settings;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataProtectionConfiguration
    {
        public static IServiceCollection ConfigureDataProtection(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration
                .GetSection(AppSettingsSections.WebWizSection)
                .Get<WebWizOptions>();

            services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(options.KeysPath));
            return services;
        }
    }
}
