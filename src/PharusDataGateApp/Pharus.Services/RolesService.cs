namespace Pharus.Services
{
    using Pharus.Data;
    using Pharus.Domain;
    using Pharus.Services.Contracts;

    using System.Linq;
    using System.Collections.Generic;

    public class RolesService : IRolesService
    {
        private readonly PharusUsersDbContext context;
        private readonly IUsersService usersService;


        public RolesService(
            PharusUsersDbContext context,
            IUsersService usersService)
        {
            this.usersService = usersService;
            this.context = context;
        }
        public List<PharusUserRole> GetAllRoles()
        {
            var roles = this.context.Roles.ToList();

            return roles;
        }

        public PharusUserRole GetRole(string roleName)
        {
            var role = this.context.Roles.SingleOrDefault(r => r.Name == roleName);

            return role;
        }
    }
}
