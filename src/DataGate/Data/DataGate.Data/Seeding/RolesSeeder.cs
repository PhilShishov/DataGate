namespace DataGate.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models;
    using DataGate.Data.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(UsersDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.InvestmentRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.RiskRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.LegalRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.ComplianceRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.GuestRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
