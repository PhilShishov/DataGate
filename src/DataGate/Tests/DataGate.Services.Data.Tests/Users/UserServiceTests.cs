// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DataGate.Data.Models.Users;
using DataGate.Services.Data.Users;
using DataGate.Services.Tests.TestData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Xunit;

namespace DataGate.Services.Data.Tests.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserServiceTests : InMemoryContextProvider
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserService service;

        public UserServiceTests()
        {
            this.userManager = UserTestData.TestUserManager(new UserStore<ApplicationUser>(base.ApplicationContext));
            this.roleManager = UserTestData.TestRoleManager(new RoleStore<ApplicationRole>(base.ApplicationContext));
            this.service = UserTestData.Service(this.userManager, this.roleManager);
        }

        [Fact]
        public async Task UserService_All_ShouldWorkCorrecty()
        {
            var result = await this.service.All();

            Assert.NotNull(result);
            Assert.True(!result.Any());
        }
    }
}