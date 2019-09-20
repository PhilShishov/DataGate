namespace Pharus.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Pharus.Domain.Users;
    using Pharus.Services.Contracts;

    public class RolesService : IRolesService
    {
        private readonly RoleManager<PharusRole> _roleManager;

        public RolesService(
            RoleManager<PharusRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public List<PharusRole> GetAllRoles()
        {
            var roles = this._roleManager.Roles.ToList();

            return roles;
        }

        public PharusRole GetRole(string roleName)
        {
            var role = this._roleManager.Roles.SingleOrDefault(r => r.Name == roleName);

            return role;
        }
    }
}
