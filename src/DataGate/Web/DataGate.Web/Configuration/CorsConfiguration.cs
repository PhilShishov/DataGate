// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("DataGatePolicy", builder =>
            {
                builder.WithOrigins(
                        "https://pharusdatagate.com",
                        "https://www.google.com",
                        "https://localhost:5001")
                       .WithMethods("PUT", "DELETE", "GET")
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            return services;
        }
    }
}
