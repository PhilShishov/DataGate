﻿// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Data;
    using DataGate.Data.Models.Columns;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Data.Layouts;

    using Microsoft.AspNetCore.Identity;

    public class LayoutTestData
    {
        public static LayoutService Service(UserManager<ApplicationUser> userManager)
        {
            var service = new LayoutService(userManager);
            return service;
        }

        public static IEnumerable<RecentlyViewed> Generate(UsersDbContext usersContext)
        {
            var list = new List<UserShareClassColumn>();

            for (int i = 1; i <= 10; i++)
            {
                var notification = new UserShareClassColumn()
                {
                    Name = $"Test{i}",
                    UserId = "testUserId",
                };

                list.Add(notification);
            }

            usersContext.UserShareClassColumn.AddRangeAsync(list);
            usersContext.SaveChangesAsync();

            return usersContext.RecentlyViewed.ToList();
        }
    }
}