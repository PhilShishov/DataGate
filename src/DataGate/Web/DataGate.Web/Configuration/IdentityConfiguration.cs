// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using DataGate.Data;
    using DataGate.Data.Models.Users;

    using Microsoft.Extensions.DependencyInjection;

    public static class IdentityConfiguration
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                 .AddRoles<ApplicationRole>()
                 .AddEntityFrameworkStores<UsersDbContext>();

            return services;
        }
    }
}
