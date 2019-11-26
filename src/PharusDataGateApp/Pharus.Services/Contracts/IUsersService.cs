namespace Pharus.Services.Contracts
{
    using System.Collections.Generic;

    using Pharus.Domain;

    public interface IUsersService
    {
        List<PharusUser> GetAllUsers();

        PharusUser GetUserByUserName(string username);

        List<PharusUser> GetAllUserRoles();
    }
}