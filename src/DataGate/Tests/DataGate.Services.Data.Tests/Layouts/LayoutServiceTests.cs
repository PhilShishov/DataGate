// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Layouts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Columns;
    using DataGate.Data.Models.Users;
    using DataGate.Data.Repositories.UsersContext;
    using DataGate.Services.Data.Layouts;
    using DataGate.Services.Tests.TestData;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Xunit;

    public class LayoutServiceTests : InMemoryContextProvider
    {
        private readonly IEnumerable<RecentlyViewed> testData;
        private readonly LayoutService service;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IUserRepository<UserShareClassColumn> repository;

        public LayoutServiceTests()
        {
            this.testData = LayoutTestData.Generate(base.UsersContext);
            this.userManager = UserTestData.TestUserManager(new UserStore<ApplicationUser>(base.UsersContext));
            this.roleManager = UserTestData.TestRoleManager(new RoleStore<ApplicationRole>(base.UsersContext));
            this.service = LayoutTestData.Service(this.userManager);
            this.repository = new EfUserRepository<UserShareClassColumn>(base.UsersContext);
        }

        [Theory]
        [InlineData("testUser", 1)]
        public void ColumnsToDb_WithValidData_ShouldWorkCorrecty(string userName, int expected)
        {
            var selectedColumns = new List<string> { "Id, Name" };
            var testUser = UserTestData.Create(this.userManager, userName, $"{userName}Id",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            var result = this.service.ColumnsToDb<UserShareClassColumn>(selectedColumns, $"{userName}Id");

            Assert.NotNull(result);
            Assert.True(result.Count() == expected);
        }

        [Fact]
        public void ColumnsToDb_WithEmptyColumns_ShouldWorkCorrecty()
        {
            var testUser = UserTestData.Create(this.userManager, "testUser", "testUserId",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            var result = this.service.ColumnsToDb<UserShareClassColumn>(null, $"testUserId");

            Assert.NotNull(result);
            Assert.True(!result.Any());
        }

        [Theory]
        [InlineData("testUser", 10)]
        [InlineData("emptyUser", 0)]
        public void GetLayout_WithValidData_ShouldWorkCorrecty(string userName, int expected)
        {
            var testUser = UserTestData.Create(this.userManager, userName, $"{userName}Id",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            //var user = await this.service.UserWithLayouts(testUser);
            var result = this.service.GetLayout<UserShareClassColumn>(this.repository, $"{userName}Id");

            Assert.NotNull(result);
            Assert.True(result.Count() == expected);
        }

        [Theory]
        [InlineData("testUser")]
        public async Task UserWithLayouts_WithValidData_ShouldWorkCorrecty(string userName)
        {
            var testUser = UserTestData.Create(this.userManager, userName, $"{userName}Id",
                this.roleManager, GlobalConstants.GuestRoleName, $"{GlobalConstants.GuestRoleName}Id");

            var user = await this.service.UserWithLayouts(testUser);

            Assert.NotNull(user);
        }
    }
}