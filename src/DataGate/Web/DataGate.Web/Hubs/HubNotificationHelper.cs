// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Web.Hubs.Contracts;

    using Microsoft.AspNetCore.SignalR;

    public class HubNotificationHelper : IHubNotificationHelper
    {
        private readonly IHubContext<NotificationHub> context;

        public HubNotificationHelper(
            IHubContext<NotificationHub> hubContext)
        {
            this.context = hubContext;
        }

        public async Task<Task> SendToAll(int count)
        {
            try
            {
                await this.context.Clients.All.SendAsync("SendNotfication", count);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}