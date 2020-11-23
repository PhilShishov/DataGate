namespace DataGate.Services.Data.Tests.Factories
{
    using System;
    using System.Data.SqlClient;

    using Microsoft.EntityFrameworkCore;
    using DataGate.Data;

     public static class ConnectionFactory
    {
        public static ApplicationDbContext CreateContextForInMemory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        public static ApplicationDbContext CreateContextForSqlServer()
        {
            var connection = new SqlConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connection)
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
