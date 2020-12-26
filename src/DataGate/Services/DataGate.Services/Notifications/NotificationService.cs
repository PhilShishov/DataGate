// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;
    using DataGate.Data.Models.Users.Enums;
    using DataGate.Services.Mapping;
    using DataGate.Services.Notifications.Contracts;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class NotificationService : INotificationService
    {
        private readonly IUserRepository<UserNotification> repository;
        private readonly UserManager<ApplicationUser> userManager;

        public NotificationService(
            IUserRepository<UserNotification> repository,
            UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public async Task Add(ClaimsPrincipal fromUser, string message, string link)
        {
            this.DoesUserExist(fromUser);

            var users = this.userManager.Users.ToList();

            var notifications = new List<UserNotification>();

            foreach (var user in users)
            {
                NotificationTemplate(message, link, notifications, user);
            }
            await this.repository.AddRangeAsync(notifications);
        }

        public async Task AddAdmin(ClaimsPrincipal fromUser, string message, string link)
        {
            this.DoesUserExist(fromUser);

            var users = this.userManager.Users.ToList();

            var notifications = new List<UserNotification>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                if (roles[0].ToString() == GlobalConstants.AdministratorRoleName)
                {
                    NotificationTemplate(message, link, notifications, user);
                }
            }
            await this.repository.AddRangeAsync(notifications);
        }

        public IEnumerable<T> All<T>(ClaimsPrincipal user)
        {
            this.DoesUserExist(user);

            var userId = this.userManager.GetUserId(user);

            var notifications = this.repository.All()
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedOn)
                .ToList();

            foreach (var notification in notifications)
            {
                notification.IsOpened = true;                
            }

            this.repository.SaveChangesAsync();          

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(notifications);
        }

        public async Task<int> Count(ClaimsPrincipal user)
        {
            this.DoesUserExist(user);

            var userId = this.userManager.GetUserId(user);

            var count = await this.repository.All()
                    .CountAsync(n => n.UserId == userId && !n.IsOpened);
            return count;
        }
        public async Task StatusAsync(ClaimsPrincipal user, string notifId)
        {
            var userId = this.userManager.GetUserId(user);

            var notification = this.repository.All()
                .FirstOrDefault(n => n.Id == notifId && n.UserId == userId);

            if (notification != null)
            {
                notification.Status = NotificationStatus.Read;
            }

            await this.repository.SaveChangesAsync();
        }

        public string GetNotificationStatus(ClaimsPrincipal user, string notifId)
        {
            var userId = this.userManager.GetUserId(user);

            return this.repository.All()
                .Where(n => n.UserId == userId && n.Id == notifId)
                .Select(n => n.Status.ToString("g"))
                .FirstOrDefault();
        }

        private void DoesUserExist(ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        private static void NotificationTemplate(string message, string link, List<UserNotification> notifications, ApplicationUser user)
        {
            var notification = new UserNotification
            {
                UserId = user.Id,
                LinkUrl = link,
                CreatedOn = DateTime.UtcNow,
                Status = NotificationStatus.Unread,
                Content = message
            };
            notifications.Add(notification);
        }
    }
}