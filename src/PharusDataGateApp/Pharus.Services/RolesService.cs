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

        public RolesService(PharusUsersDbContext context)
        {
            this.context = context;
        }
        public List<PharusUserRole> GetAllRoles()
        {
            List<PharusUserRole> roles = this.context.Roles.ToList();

            return roles;
        }

        //public PharusUserRole GetUserRole(string roleName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
