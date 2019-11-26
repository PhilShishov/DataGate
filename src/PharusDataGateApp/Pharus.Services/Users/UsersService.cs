namespace Pharus.Services.Users
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Domain;
    using Pharus.Services.Contracts;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly UserManager<PharusUser> userManager;

        public UsersService(
            UserManager<PharusUser> userManager)
        {
            this.userManager = userManager;
        }

        public List<PharusUser> GetAllUsers()
        {
            List<PharusUser> users = this.userManager.Users.ToList();

            return users;
        }

        public PharusUser GetUserByUserName(string username)
        {
            PharusUser userDb = this.userManager.Users.SingleOrDefault(user => user.UserName == username);

            return userDb;
        }

        public List<PharusUser> GetAllUserRoles()
        {
            var users = this.userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();

            return users;
        }
    }
}
