
namespace DataGate.Web.Configuration
{
    using DataGate.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class CacheConfiguration
    {
        public const string SchemaName = "dbo";
        public const string TableName = "Cache";

        //public static IServiceCollection ConfigureDistributedSqlServerCache(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDistributedSqlServerCache(options =>
        //    {
        //        options.ConnectionString = configuration.GetConnectionString(GlobalConstants.DefaultConnectionStringName);
        //        options.SchemaName = SchemaName;
        //        options.TableName = TableName;
        //    });

        //    return services;
        //}
    }
}
