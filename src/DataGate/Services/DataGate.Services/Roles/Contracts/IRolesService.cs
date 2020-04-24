namespace DataGate.Services.Roles.Contracts
{
    using System.Collections.Generic;

    using DataGate.Domain.Models.Users;

    public interface IRolesService
    {
        List<PharusRole> GetAllRoles();

        PharusRole GetRole(string roleName);
    }
}