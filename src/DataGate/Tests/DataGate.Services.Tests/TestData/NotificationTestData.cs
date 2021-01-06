// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DataGate.Data;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;
    using DataGate.Data.Repositories.UsersContext;
    using DataGate.Services.Notifications;

    using Microsoft.AspNetCore.Identity;

    using Moq;

    public class NotificationTestData
    {
        public static IEnumerable<UserNotification> GenerateNotifications()
        {
            for (int i = 1; i < 10; i++)
            {
                yield return new UserNotification
                {
                    //ScId = i,
                    //ScOfficialShareClassName = $"pharus#{i}",
                    //ScIsinCode = $"LU0000{i}",
                    //ScInitialDate = new DateTime(2020, 01, i),
                };
            }
        }

        public static NotificationService Service(
            IEnumerable<UserNotification> testData,
            UsersDbContext context)
        {
            //context.UserNotifications.AddRangeAsync(testData);
            //context.SaveChangesAsync();

            IUserRepository<UserNotification> repository = new EfUserRepository<UserNotification>(context);

            var store = new Mock<IUserStore<ApplicationUser>>();
            var user = new ApplicationUser { UserName = "test", Email = "test@test.com"};
            var userManager = UserTestData.MockUserManager(store.Object);
            store.Setup(s => s.CreateAsync(user, CancellationToken.None)).ReturnsAsync(IdentityResult.Success).Verifiable();
            store.Setup(s => s.GetUserNameAsync(user, CancellationToken.None)).Returns(Task.FromResult(user.UserName)).Verifiable();
            store.Setup(s => s.SetNormalizedUserNameAsync(user, user.UserName.ToUpperInvariant(), CancellationToken.None)).Returns(Task.FromResult(0)).Verifiable();


            userManager.CreateAsync(user);

            var service = new NotificationService(repository, userManager);
            return service;
        }
    }
}