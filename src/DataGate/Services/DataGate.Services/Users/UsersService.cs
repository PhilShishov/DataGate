// Service class for managing users

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Users
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using DataGate.Domain.Models.Users;
    using DataGate.Services.Users.Contracts;

    // _____________________________________________________________
    public class UsersService : IUsersService
    {
        private readonly UserManager<PharusUser> userManager;

        // ________________________________________________________
        //
        // Constructor: initialize with identity user manager
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
            PharusUser userDb = this.userManager
                .Users
                .SingleOrDefault(user => user.UserName == username);

            return userDb;
        }

        public List<PharusUser> GetAllUserRoles()
        {
            var users = this.userManager
                .Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToList();

            return users;
        }
    }
}
