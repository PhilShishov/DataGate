namespace Pharus.Services.Contracts
{
    using Pharus.Domain;

    using System.Collections.Generic;

    public interface IRolesService
    {
        List<PharusUserRole> GetAllRoles();

        PharusUserRole GetRole(string roleName);
    }
}