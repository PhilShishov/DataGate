// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    using DataGate.Data;
    using DataGate.Data.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Common.Repositories.UsersContext; 
    using DataGate.Data.Repositories.AppContext;
    using DataGate.Data.Repositories.UsersContext;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;

    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IAppRepository<>), typeof(EfAppRepository<>));
            services.AddScoped(typeof(IUserRepository<>), typeof(EfUserRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();
            services.AddScoped<ISqlQueryManager, SqlQueryManager>();
            services.AddScoped<ISubFundRepository, SubFundRepository>();
            services.AddScoped<IShareClassRepository, ShareClassRepository>();
            services.AddScoped<ITimeSeriesRepository, TimeSeriesRepository>();
            services.AddScoped<IAgreementsRepository, AgreementsRepository>();

            return services;
        }
    }
}
