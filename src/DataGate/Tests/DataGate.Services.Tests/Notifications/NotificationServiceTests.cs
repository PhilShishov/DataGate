// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Notifications
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Users;
    using DataGate.Services.Notifications;
    using DataGate.Services.Tests.TestData;

    public class NotificationServiceTests : InMemoryContextProvider
    {
        private readonly IEnumerable<UserNotification> testData;
        private readonly NotificationService service;

        public NotificationServiceTests()
        {
            this.testData = NotificationTestData.GenerateNotifications();
            this.service = NotificationTestData.Service(testData, base.context);
        }


    }
}