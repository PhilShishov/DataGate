namespace Pharus.Services.Users.Contracts
{
    using System.Collections.Generic;

    using Pharus.Domain.Models.Users;

    public interface IUsersService
    {
        List<PharusUser> GetAllUsers();

        PharusUser GetUserByUserName(string username);

        List<PharusUser> GetAllUserRoles();
    }
}