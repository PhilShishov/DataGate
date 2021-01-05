// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Moq;

    public class MockUserManager
    {
        public static UserManager<TUser> Create<TUser>() 
            where TUser : class
        {
            Mock<IUserPasswordStore<TUser>> userPasswordStore = new Mock<IUserPasswordStore<TUser>>();
            userPasswordStore.Setup(s => s.CreateAsync(It.IsAny<TUser>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();

            idOptions.Lockout.AllowedForNewUsers = false;
            idOptions.Password.RequireDigit = true;
            idOptions.Password.RequireLowercase = true;
            idOptions.Password.RequireNonAlphanumeric = true;
            idOptions.Password.RequireUppercase = true;
            idOptions.Password.RequiredLength = 8;
            idOptions.Password.RequiredUniqueChars = 1;

            idOptions.SignIn.RequireConfirmedEmail = false;

            idOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            idOptions.Lockout.MaxFailedAccessAttempts = 5;
            idOptions.Lockout.AllowedForNewUsers = true;

            options.Setup(o => o.Value).Returns(idOptions);
            var userValidators = new List<IUserValidator<TUser>>();
            UserValidator<TUser> validator = new UserValidator<TUser>();
            userValidators.Add(validator);

            var passValidator = new PasswordValidator<TUser>();
            var pwdValidators = new List<IPasswordValidator<TUser>>();
            pwdValidators.Add(passValidator);
            var userManager = new UserManager<TUser>(userPasswordStore.Object, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);

            return userManager;
        }
    }
}