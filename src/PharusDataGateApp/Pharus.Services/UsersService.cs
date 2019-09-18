namespace Pharus.Services
{
    using Pharus.Data;
    using Pharus.Domain;
    using Pharus.Services.Contracts;

    using System.Linq;
    using System.Collections.Generic;

    public class UsersService : IUsersService
    {
        private readonly PharusUsersDbContext pharusDbContext;

        public UsersService(PharusUsersDbContext pandaDbContext)
        {
            this.pharusDbContext = pandaDbContext;
        }

        public List<PharusUser> GetAllUsers()
        {
            List<PharusUser> users = this.pharusDbContext.Users.ToList();

            return users;
        }

        public PharusUser GetUser(string username)
        {
            PharusUser userDb = this.pharusDbContext.Users.SingleOrDefault(user => user.UserName == username);

            return userDb;
        }
    }
}
