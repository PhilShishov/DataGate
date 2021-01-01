// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs.Contracts
{
    using System.Threading.Tasks;

    using DataGate.Web.Dtos.Notifications;

    public interface IHubNotificationHelper
    {
        Task SendToAll(NotificationDto dto);

        Task SendToAdmin(NotificationDto dto);

        Task<Task> HubToAll(int count, bool isAdmin = false);
    }
}
