
namespace Pharus.App.Extensions
{
    using System.Linq;
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using Pharus.Data;
    using Pharus.Data.Seeding;

    public static class ApplicationBuilderExtensions
    {
        public static void UseDatabaseSeeding(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider
                    .GetRequiredService<PharusUsersDbContext>();

                context.Database.EnsureCreated();

                Assembly
                    .GetAssembly(typeof(PharusUsersDbContext))
                    .GetTypes()
                    .Where(type => typeof(ISeeder).IsAssignableFrom(type))
                    .Where(type => type.IsClass)
                    .Select(type => (ISeeder)serviceScope.ServiceProvider.GetRequiredService(type))
                    .ToList()
                    .ForEach(seeder => seeder.Seed());
            }
        }
    }
}
