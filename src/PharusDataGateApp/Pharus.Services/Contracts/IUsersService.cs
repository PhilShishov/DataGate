namespace Pharus.Services.Contracts
{
    using System.Collections.Generic;

    using Pharus.Domain;

    public interface IUsersService
    {
        List<PharusUser> GetAllUsers();

        PharusUser GetUserByUserName(string username);

        //PharusUser GetUserByID(string id);

        List<PharusUser> GetAllUserRoles();

    }
}