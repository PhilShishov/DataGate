// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Extensions.DependencyInjection;

    public static class FormsConfiguration
    {
        public static IServiceCollection ConfigureForms(this IServiceCollection services)
        {
            // ---------------------------------------------------------
            //
            // Enable multiple get/post forms
            // Error: Form value count limit 1024 exceeded.
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });

            return services;
        }
    }
}
