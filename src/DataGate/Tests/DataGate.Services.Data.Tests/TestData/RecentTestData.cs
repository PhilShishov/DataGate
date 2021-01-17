// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using DataGate.Services.Data.Recent;

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

    public class RecentTestData
    {
        public static List<RecentlyViewed> Generate(UsersDbContext context)
        {
            var list = new List<RecentlyViewed>();

            for (int i = 1; i <= 10; i++)
            {
                var notification = new RecentlyViewed()
                {
                    LinkUrl = "/testurl",
                    UserId = "testUserId",
                    DisplayLink = $"Link {i}",
                    VisitedOn = DateTime.UtcNow.AddHours(i * (-i))
                };

                list.Add(notification);
            }

            for (int i = 1; i <= 10; i++)
            {
                var notification = new RecentlyViewed()
                {
                    LinkUrl = "/testurl",
                    UserId = "otherUserId",
                    DisplayLink = $"Link {i}",
                    VisitedOn = DateTime.UtcNow.AddHours(i * (-i))
                };

                list.Add(notification);
            }

            context.RecentlyViewed.AddRangeAsync(list);
            context.SaveChangesAsync();

            return context.RecentlyViewed.ToList();
        }

        public static RecentService Service(UsersDbContext context, UserManager<ApplicationUser> userManager)
        {
            IUserRepository<RecentlyViewed> repository = new EfUserRepository<RecentlyViewed>(context);
            var service = new RecentService(repository, userManager);
            return service;
        }
    }
}