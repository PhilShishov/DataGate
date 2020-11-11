namespace DataGate.Services.Data.Tests.Factories
{
    using System;

    using DataGate.Data;
    using Microsoft.EntityFrameworkCore;

     public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext CreateInMemoryDatabase()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
