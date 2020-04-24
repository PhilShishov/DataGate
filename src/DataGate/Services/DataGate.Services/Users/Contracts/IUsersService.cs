namespace DataGate.Services.Users.Contracts
{
    using System.Collections.Generic;

    using DataGate.Domain.Models.Users;

    public interface IUsersService
    {
        List<PharusUser> GetAllUsers();

        PharusUser GetUserByUserName(string username);

        List<PharusUser> GetAllUserRoles();
    }
}