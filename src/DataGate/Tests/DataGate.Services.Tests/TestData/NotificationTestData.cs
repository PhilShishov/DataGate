// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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

    public class NotificationTestData
    {
        public static List<UserNotification> Generate(UsersDbContext context)
        {
            var list = new List<UserNotification>();

            for (int i = 1; i < 5; i++)
            {
                var notification = new UserNotification
                {
                    Content = "TestMessage",
                    LinkUrl = "/testurl",
                    UserId = "testAdminId",
                    Status = NotificationStatus.Unread,
                };
                list.Add(notification);
            }

            for (int i = 1; i < 5; i++)
            {
                var notification = new UserNotification
                {
                    Content = "TestMessage",
                    LinkUrl = "/testurl",
                    UserId = "testGuestId",
                    Status = NotificationStatus.Unread,
                };
                list.Add(notification);
            }

            context.UserNotifications.AddRangeAsync(list);
            context.SaveChangesAsync();

            return context.UserNotifications.ToList();
        }

        public static string ByUserId(UsersDbContext context, string userId)
        {
            var list = context.UserNotifications.ToList();
            return list.Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public static NotificationService Service(UsersDbContext context, UserManager<ApplicationUser> userManager)
        {
            IUserRepository<UserNotification> repository = new EfUserRepository<UserNotification>(context);
            var service = new NotificationService(repository, userManager);
            return service;
        }
    }
}