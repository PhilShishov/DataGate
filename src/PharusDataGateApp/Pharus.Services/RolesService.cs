namespace Pharus.Services
{
    using Pharus.Data;
    using Pharus.Services.Contracts;

    using System.Linq;
    using System.Collections.Generic;
    using Pharus.Domain.Users;

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
        public List<PharusRole> GetAllRoles()
        {
            var roles = this.context.Roles.ToList();

            return roles;
        }

        public PharusRole GetRole(string roleName)
        {
            var role = this.context.Roles.SingleOrDefault(r => r.Name == roleName);

            return role;
        }
    }
}
