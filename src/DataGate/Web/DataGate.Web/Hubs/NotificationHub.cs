// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Services.Notifications.Contracts;

    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub
    {
        private IConnectionManager connectionManager;

        public NotificationHub(
            IConnectionManager connection)
        {
            this.connectionManager = connection;
        }

        public string GetConnectionId()
        {
            var username = this.Context.User.Identity.Name;
            this.connectionManager.AddConnection(username, this.Context.ConnectionId);

            return this.Context.ConnectionId;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exc)
        {
            return base.OnDisconnectedAsync(exc);
        }
    }
}