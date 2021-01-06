// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Moq;

    public class UserTestData
    {
        public static UserManager<TUser> MockUserManager<TUser>(IUserStore<TUser> store = null)
            where TUser : class
        {
            store = store ?? new Mock<IUserStore<TUser>>().Object;
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

        public static ClaimsPrincipal Create()
        {
            var claims = new List<Claim>()                
            {
                new Claim(ClaimTypes.Name, "test"),
                new Claim("name", "test"),                
            };

            var identity = new ClaimsIdentity(claims, "TestAuthType");
            return new ClaimsPrincipal(identity);
        }
    }
}