namespace DataGate.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(UsersDbContext dbContext, IServiceProvider serviceProvider);
    }
}
