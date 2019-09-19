namespace Pharus.Services.Contracts
{
    using Pharus.Domain.Users;
    using System.Collections.Generic;

    public interface IRolesService
    {
        List<PharusRole> GetAllRoles();

        PharusRole GetRole(string roleName);
    }
}