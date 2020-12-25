
namespace DataGate.Services.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories.UsersContext;
    using DataGate.Data.Models.Users;
    using DataGate.Data.Models.Users.Enums;

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
            if (fromUser == null)
            {
                throw new ArgumentNullException(nameof(fromUser));
            }

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
            if (fromUser == null)
            {
                throw new ArgumentNullException(nameof(fromUser));
            }

            var users = this.userManager.Users.ToList();

            var notifications = new List<UserNotification>();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                if (roles[0].ToString() == "Admin")
                {
                    NotificationTemplate(message, link, notifications, user);
                }
            }
            await this.repository.AddRangeAsync(notifications);
        }

        public async Task<int> Count(ClaimsPrincipal user)
        {
            var userId = this.userManager.GetUserId(user);

            var count = await this.repository.All()
                    .CountAsync(x => x.UserId == userId && x.Status == NotificationStatus.Unread);
            return count;
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