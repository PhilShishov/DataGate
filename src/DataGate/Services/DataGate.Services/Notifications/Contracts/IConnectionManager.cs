// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Notifications.Contracts
{
    using System.Collections.Generic;

    public interface IConnectionManager
    {
        void AddConnection(string username, string connectionId);

        void RemoveConnection(string connectionId);

        HashSet<string> GetConnections(string username);

        IEnumerable<string> OnlineUsers { get; }
    }
}