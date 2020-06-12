namespace DataGate.Web.Configuration
{
    using System.IO;

    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataProtectionConfiguration
    {
        public static IServiceCollection ConfigureDataProtection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(configuration.GetValue<string>("WebWiz:KeysPath")));
            return services;
        }
    }
}
