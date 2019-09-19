namespace Pharus.Services
{
    using Pharus.Data;
    using Pharus.Domain;
    using Pharus.Services.Contracts;

    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly PharusUsersDbContext context;
        private readonly UserManager<PharusUser> _userManager;

        public UsersService(
            PharusUsersDbContext context, 
            UserManager<PharusUser> userManager)
        {
            this.context = context;
            _userManager = userManager;
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

        //public IList<string> GetAllUserRoles(string username)
        //{
        //    var user = this.context.Users.SingleOrDefault(u =>u.UserName == username);
        //    var roles = (IList<string>)this._userManager.GetRolesAsync(user);

        //    return roles;
        //}
    }
}
