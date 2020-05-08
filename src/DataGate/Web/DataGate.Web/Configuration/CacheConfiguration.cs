namespace DataGate.Web.Configuration
{
    using Microsoft.AspNetCore.Builder;
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
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
            return services;
        }
    }
}
