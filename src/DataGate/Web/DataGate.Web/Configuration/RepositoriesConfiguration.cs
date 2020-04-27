namespace DataGate.Web.Configuration
{
    using DataGate.Data;
    using DataGate.Data.Common;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            return services;
        }
    }
}
