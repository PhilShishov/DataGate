// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Notifications.Contracts;
    using DataGate.Web.Dtos.Notifications;
    using DataGate.Web.Hubs.Contracts;

    using Microsoft.AspNetCore.SignalR;

    public class HubNotificationHelper : IHubNotificationHelper
    {
        private readonly INotificationService notificationService;
        private readonly IHubContext<NotificationHub> context;

        public HubNotificationHelper(
            INotificationService notificationService,
            IHubContext<NotificationHub> hubContext)
        {
            this.notificationService = notificationService;
            this.context = hubContext;
        }
        public async Task SendToAll(NotificationDto dto)
        {
            var notifMessage = string.Format(dto.Message, dto.Arg);
            await this.notificationService.Add(dto.User, notifMessage, dto.Link);
            int count = await this.notificationService.Count(dto.User);

            //await this.HubToAll(count);
        }

        public async Task SendToAdmin(NotificationDto dto)
        {
            var notifMessage = string.Format(dto.Message, dto.Arg);
            await this.notificationService.AddAdmin(dto.User, notifMessage, dto.Link);
            int count = await this.notificationService.Count(dto.User);

            await this.HubToAll(count, true);
        }

        public async Task<Task> HubToAll(int count, bool isAdmin = false)
        {
            try
            {
                if (isAdmin)
                {
                    await this.context.Clients.Group(GlobalConstants.AdministratorRoleName).SendAsync(GlobalConstants.SocketSendNotification, count);
                    return Task.CompletedTask;
                }

                await this.context.Clients.All.SendAsync(GlobalConstants.SocketSendNotification, count);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}