// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Notifications;
    using DataGate.Services.Tests.TestData;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Xunit;

    public class NotificationServiceTests : InMemoryContextProvider
    {
        private readonly IEnumerable<UserNotification> testData;
        private readonly NotificationService service;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ClaimsPrincipal admin;
        private readonly ClaimsPrincipal guest;
        private const string Message = "TestMessage";
        private const string Link = "/testurl";

        public NotificationServiceTests()
        {
            this.testData = NotificationTestData.Generate(base.Context);
            this.userManager = UserTestData.TestUserManager(new UserStore<ApplicationUser>(base.Context));
            this.service = NotificationTestData.Service(base.Context, this.userManager);

            this.admin = UserTestData.Create(this.userManager, "testAdmin", "testAdminId", 
                GlobalConstants.AdministratorRoleName);
            this.guest = UserTestData.Create(this.userManager, "testGuest", "testGuestId",
                GlobalConstants.GuestRoleName);
        }

        [Fact]
        public async Task Add_WithValidData_ShouldWorkCorrecty()
        {
            await this.service.Add(this.admin, Message, Link);

            Assert.Equal(base.Context.UserNotifications.First().Content, Message);
            Assert.Equal(base.Context.UserNotifications.First().LinkUrl, Link);
            Assert.True(base.Context.UserNotifications.First().Id != null);
        }

        [Fact]
        public async Task Add_HundredTimesWithTwoUsers_ShouldWorkCorrecty()
        {
            var count = 100;
            for (int i = 0; i < count; i++)
            {
                await this.service.Add(this.admin, Message, Link);
            }

            var users = base.Context.Users.Count();
            var generated = this.testData.Count();
            var expected = count * users + generated;

            Assert.Equal(expected, base.Context.UserNotifications.Count());
        }

        [Fact]
        public async Task Add_WithNullUser_ShouldThrowException()
        {
            await Assert.ThrowsAsync<EntityNotFoundException>(() 
                => this.service.Add(null, Message, Link));
        }

        [Theory]
        [InlineData(null, Link)]
        [InlineData("", Link)]
        [InlineData("       ", Link)]
        [InlineData(Message, null)]
        [InlineData(Message, "")]
        [InlineData(Message, "      ")]
        public async Task Add_WithInvalidDataAndValidUser_ShouldThrowException(string message, string link)
        {
            async Task task() => await this.service.Add(this.admin, message, link);

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        //[Fact]
        //public async Task AddAdmin_WithValidData_ShouldWorkCorrectly()
        //{
        //    await this.service.AddAdmin(this.admin, Message, Link);

        //    Assert.Equal(base.Context.UserNotifications.First().Content, Message);
        //    Assert.Equal(base.Context.UserNotifications.First().LinkUrl, Link);
        //    Assert.True(base.Context.UserNotifications.First().Id != null);
        //}

        [Fact]
        public async Task All_ForAdmin_ShouldReturnSameResultFromDb()
        {
            var task = await this.service.All<UserNotification>(this.admin);
            var notifications = task.ToList();

            var actual = this.testData.Where(x => x.UserId == "testAdminId").ToList();

            Assert.Equal(actual.Count, notifications.Count);

            for (int i = 0; i < notifications.Count; i++)
            {
                Assert.Equal(notifications[i].Id, actual[i].Id);
                Assert.Equal(notifications[i].Content, actual[i].Content);
            }
        }


        [Fact]
        public async Task All_WithNullUser_ShouldThrowException()
        {
            await Assert.ThrowsAsync<EntityNotFoundException>(() => this.service.All<UserNotification>(null));
        }

        [Fact]
        public async Task All_Opened_ShouldBeTrue()
        {
            var task = await this.service.All<UserNotification>(this.admin);
            var notifications = task.ToList();

            for (int i = 0; i < notifications.Count; i++)
            {
                Assert.True(notifications[i].IsOpened);
            }
        }

        [Fact]
        public async Task All_WithMoreThanTen_ShouldReturnTen()
        {
            for (int i = 0; i < 20; i++)
            {
                await this.service.Add(this.admin, Message, Link);
            }

            var task = await this.service.All<UserNotification>(this.admin);
            var notifications = task.ToList();

            Assert.Equal(10, notifications.Count);
        }

        [Fact]
        public async Task Count_ShouldReturnCorrectNumber()
        {
            var countBeforeAdd = await this.service.Count(this.admin);
            Assert.Equal(4, countBeforeAdd);
            for (int i = 0; i < 20; i++)
            {
                await this.service.Add(this.admin, Message, Link);
            }

            var countAfterAdd = await this.service.Count(this.admin);
            Assert.Equal(24, countAfterAdd);
        }

        [Fact]
        public async Task Count_WithNullUser_ShouldThrowException()
        {
            await Assert.ThrowsAsync<EntityNotFoundException>(() => this.service.Count(null));
        }

        [Fact]
        public void GetStatus_ShouldReturnStringResult()
        {
            var notifId = NotificationTestData.ByUserId(base.Context, "testAdminId");

            Assert.Equal("Unread", this.service.GetStatus(this.admin, notifId));
        }

        [Fact]
        public void GetStatus_WithNullUser_ShouldThrowException()
        {
            Assert.Throws<EntityNotFoundException>(() => this.service.GetStatus(null, ""));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void GetStatus_WithInvalidDataAndValidUser_ShouldThrowException(string notifId)
        {
            Assert.Throws<ArgumentNullException>(() => this.service.GetStatus(this.admin, notifId));
        }

        [Fact]
        public async Task StatusAsync_ShouldChangeStatus()
        {
            var notifId = NotificationTestData.ByUserId(base.Context, "testAdminId");
            Assert.Equal("Unread", this.service.GetStatus(this.admin, notifId));

            await this.service.StatusAsync(this.admin, notifId);

            Assert.Equal("Read", this.service.GetStatus(this.admin, notifId));
        }

        [Fact]
        public async Task StatusAllAsync_ShouldChangeStatus()
        {
            await this.service.StatusAllAsync(this.admin);

            var notifications = base.Context.UserNotifications.ToList().Where(x => x.UserId == "testAdminId");

            foreach (var item in notifications)
            {
                Assert.Equal("Read", this.service.GetStatus(this.admin, item.Id));
            }
        }
    }
}