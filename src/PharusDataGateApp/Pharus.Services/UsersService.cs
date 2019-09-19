namespace Pharus.Services
{
    using Pharus.Data;
    using Pharus.Domain;
    using Pharus.Services.Contracts;

    using System.Linq;
    using System.Collections.Generic;

    public class UsersService : IUsersService
    {
        private readonly PharusUsersDbContext context;

        public UsersService(PharusUsersDbContext context)
        {
            this.context = context;
        }

        public List<PharusUser> GetAllUsers()
        {
            List<PharusUser> users = this.context.Users.ToList();

            return users;
        }

        public PharusUser GetUser(string username)
        {
            PharusUser userDb = this.context.Users.SingleOrDefault(user => user.UserName == username);

            return userDb;
        }
    }
}
