// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Data.Models.Users;
    using DataGate.Services.Notifications.Contracts;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationService notificationService;
        private IConnectionManager connectionManager;

        public NotificationHub(
            UserManager<ApplicationUser> userManager,
            INotificationService notificationService,
            IConnectionManager connection)
        {
            this.userManager = userManager;
            this.notificationService = notificationService;
            this.connectionManager = connection;
        }

        public string GetConnectionId()
        {
            var username = this.Context.User.Identity.Name;
            this.connectionManager.AddConnection(username, this.Context.ConnectionId);

            return this.Context.ConnectionId;
        }

        public async Task<int> GetUserNotificationCount()
            => await this.notificationService.Count(this.Context.User);

        public override Task OnConnectedAsync()
            => base.OnConnectedAsync();

        public override Task OnDisconnectedAsync(Exception ex)
            => base.OnDisconnectedAsync(ex);
    }
}