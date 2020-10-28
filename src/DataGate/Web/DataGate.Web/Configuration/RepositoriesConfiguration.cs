namespace DataGate.Web.Configuration
{
    using DataGate.Data;
    using DataGate.Data.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Repositories;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
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
