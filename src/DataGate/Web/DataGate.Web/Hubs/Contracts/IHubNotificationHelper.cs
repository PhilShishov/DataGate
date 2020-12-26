// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Hubs.Contracts
{
    using System.Threading.Tasks;

    public interface IHubNotificationHelper
    {
        Task<Task> SendToAll(int count);
    }
}
