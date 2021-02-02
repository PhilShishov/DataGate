// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DataGate.Data.Models.Columns;
using DataGate.Services.Data.Layouts;
using DataGate.Services.Data.Recent;
using DataGate.Services.Data.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace DataGate.Services.Tests.TestData
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Data;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;
    using DataGate.Data.Models.Users.Enums;
    using DataGate.Data.Repositories.UsersContext;
    using DataGate.Services.Notifications;

    using Microsoft.AspNetCore.Identity;

    public class UserTestData
    {
        public static UserService Service(UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            var service = new UserService(userManager, roleManager);
            return service;
        }

        public static UserManager<TUser> TestUserManager<TUser>(IUserStore<TUser> store)
            where TUser : class
        {
            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();
            idOptions.Lockout.AllowedForNewUsers = false;
            options.Setup(o => o.Value).Returns(idOptions);
            var userValidators = new List<IUserValidator<TUser>>();
            var validator = new Mock<IUserValidator<TUser>>();
            userValidators.Add(validator.Object);
            var pwdValidators = new List<PasswordValidator<TUser>>();
            pwdValidators.Add(new PasswordValidator<TUser>());
            var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);
            validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
                .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            return userManager;
        }

        public static RoleManager<TRole> TestRoleManager<TRole>(IRoleStore<TRole> store)
            where TRole : class
        {
            var roleValidators = new List<IRoleValidator<TRole>>();
            var validator = new Mock<IRoleValidator<TRole>>();
            roleValidators.Add(validator.Object);
            
            var roleManager = new RoleManager<TRole>(store,
                roleValidators, 
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                new Mock<ILogger<RoleManager<TRole>>>().Object);
            
            validator.Setup(v => v.ValidateAsync(roleManager, It.IsAny<TRole>()))
                .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            
            return roleManager;
        }

        public static ClaimsPrincipal Create(UserManager<ApplicationUser> userManager, string userName, string userId,
            RoleManager<ApplicationRole> roleManager, string roleName, string roleId)
        {
            var role = new ApplicationRole { Name = roleName, Id = roleId };
            roleManager.CreateAsync(role);

            var user = new ApplicationUser { UserName = userName, Id = userId };

            userManager.CreateAsync(user);
            userManager.AddToRoleAsync(user, roleManager.Roles.FirstOrDefault(r => r.Id == roleId)?.Name);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, roleName),
            };

            userManager.AddClaimsAsync(user, claims);

            var identity = new ClaimsIdentity(claims);
            return new ClaimsPrincipal(identity);
        }
    }
}