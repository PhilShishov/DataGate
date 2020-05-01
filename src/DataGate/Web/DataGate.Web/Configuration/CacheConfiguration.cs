namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    //using Microsoft.Extensions.Caching.SqlServer;

    public static class CacheConfiguration
    {
        public const string SchemaName = "dbo";
        public const string TableName = "Cache";

        public static IServiceCollection ConfigureCache(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString = configuration.GetConnectionString(GlobalConstants.DefaultConnectionStringName);
            //    options.SchemaName = SchemaName;
            //    options.TableName = TableName;
            //});

            services.AddMemoryCache();
            services.AddResponseCaching();
            return services;
        }
    }
}
