// Service class for managing user roles

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Roles
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using DataGate.Domain.Models.Users;
    using DataGate.Services.Roles.Contracts;

    // _____________________________________________________________
    public class RolesService : IRolesService
    {
        private readonly RoleManager<PharusRole> roleManager;

        // ________________________________________________________
        //
        // Constructor: initialize with identity role manager
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
