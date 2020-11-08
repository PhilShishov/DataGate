namespace DataGate.Data
{
    using System.IO;

    using DataGate.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
    {
        public UsersDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<UsersDbContext>();
            var connectionString = configuration.GetConnectionString(GlobalConstants.DataGateUsersConnection);
            builder.UseSqlServer(connectionString);

            return new UsersDbContext(builder.Options);
        }
    }
}
