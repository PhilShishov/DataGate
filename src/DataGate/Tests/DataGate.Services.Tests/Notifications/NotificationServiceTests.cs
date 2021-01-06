// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Notifications
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Data.Models.Users;
    using DataGate.Services.Notifications;
    using DataGate.Services.Tests.TestData;

    using Microsoft.AspNetCore.Identity;

    using Xunit;

    public class NotificationServiceTests : InMemoryContextProvider
    {
        private readonly IEnumerable<UserNotification> testData;
        private readonly NotificationService service;
        private readonly ClaimsPrincipal user;
        private const string Message = "TestMessage";
        private const string Link = "/test";

        public NotificationServiceTests()
        {
            this.testData = NotificationTestData.GenerateNotifications();
            this.service = NotificationTestData.Service(testData, base.Context);
            this.user = UserTestData.Create();
        }

        [Fact]
        public async Task Add_WithValidData_ShouldWorkCorrecty()
        {
            await this.service.Add(this.user, Message, Link);

            Assert.Equal(base.Context.UserNotifications.First().Content, Message);
            Assert.Equal(base.Context.UserNotifications.First().LinkUrl, Link);
            Assert.True(base.Context.UserNotifications.First().Id != null);
        }
    }
}