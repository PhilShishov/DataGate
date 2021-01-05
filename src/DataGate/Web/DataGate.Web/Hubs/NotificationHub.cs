// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Notifications.Contracts;

    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub
    {
        private static string[] Admins = { "philip.shishov", "fabio.martis" };
        private readonly INotificationService notificationService;
        private IConnectionManager connectionManager;

        public NotificationHub(
            INotificationService notificationService,
            IConnectionManager connection)
        {
            this.notificationService = notificationService;
            this.connectionManager = connection;
        }

        public string ConnectionId()
        {
            var username = this.Context.User.Identity.Name;
            this.connectionManager.AddConnection(username, this.Context.ConnectionId);

            return this.Context.ConnectionId;
        }

        public async Task<int> NotificationCount()
            => await this.notificationService.Count(this.Context.User);

        public async Task JoinAdmin()
         => await this.Groups.AddToGroupAsync(this.ConnectionId(), GlobalConstants.AdministratorRoleName);

        public override Task OnConnectedAsync()
            => base.OnConnectedAsync();
        
        public override Task OnDisconnectedAsync(Exception ex)
            => base.OnDisconnectedAsync(ex);
    }
}