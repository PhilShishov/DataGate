namespace Pharus.Services.Roles
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Pharus.Domain.Users;
    using Pharus.Services.Contracts;

    public class RolesService : IRolesService
    {
        private readonly RoleManager<PharusRole> roleManager;

        public RolesService(
            RoleManager<PharusRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public List<PharusRole> GetAllRoles()
        {
            var roles = this.roleManager.Roles.ToList();

            return roles;
        }

        public PharusRole GetRole(string roleName)
        {
            var role = this.roleManager.Roles.SingleOrDefault(r => r.Name == roleName);

            return role;
        }
    }
}
