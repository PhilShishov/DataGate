// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Recent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Data.Recent;
    using DataGate.Services.Tests.TestData;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Xunit;

    public class RecentServiceTests : InMemoryContextProvider
    {
        private readonly IEnumerable<RecentlyViewed> testData;
        private readonly RecentService service;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public RecentServiceTests()
        {
            this.testData = RecentTestData.Generate(base.UsersContext);
            this.userManager = UserTestData.TestUserManager(new UserStore<ApplicationUser>(base.ApplicationContext));
            this.roleManager = UserTestData.TestRoleManager(new RoleStore<ApplicationRole>(base.UsersContext));
            this.service = RecentTestData.Service(base.UsersContext, this.userManager);
        }

        [Theory]
        [InlineData("testUser", 8)]
        [InlineData("emptyUser", 0)]
        public void ByUserId_WithValidData_ShouldWorkCorrecty(string userName, int expected)
        {
            var user = UserTestData.Create(this.userManager, userName, $"{userName}Id",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            var result = this.service.ByUserId(user);

            Assert.NotNull(result);
            Assert.True(result.Count() == expected);
        }

        [Fact]
        public void ByUserId_WithInvalidData_ShouldThrowException()
        {
            Action act = () =>
            {
                this.service.ByUserId(null);
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("testUser", "server/page")]
        [InlineData("emptyUser", "server/page")]
        [InlineData("testUser", "/testurl")]
        public async Task Save_WithValidData_ShouldWorkCorrecty(string userName, string link)
        {
            var user = UserTestData.Create(this.userManager, userName, $"{userName}Id",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            await this.service.Save(user, link);

            var result = this.service.ByUserId(user);
            Assert.NotNull(result.FirstOrDefault(r => r.LinkUrl.Equals(link)));
        }

        [Fact]
        public async Task Save_WithInvalidDataUser_ShouldThrowException()
        {
            async Task act()
            {
                await this.service.Save(null, "");
            };

            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async Task Save_WithInvalidDataLink_ShouldThrowException()
        {
            var user = UserTestData.Create(this.userManager, "testUser", "testUserId",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            async Task act()
            {
                await this.service.Save(user, "");
            };

            await Assert.ThrowsAsync<IndexOutOfRangeException>(act);
        }
    }
}