// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Notifications
{
    using System;
    using System.Collections.Generic;

    using DataGate.Common;
    using DataGate.Services.Notifications.Contracts;

    public class ConnectionManager : IConnectionManager
    {
        private static readonly Dictionary<string, HashSet<string>> userMap =
            new Dictionary<string, HashSet<string>>();

        public IEnumerable<string> OnlineUsers
        {
            get => userMap.Keys;
        }

        public void AddConnection(string username, string connectionId)
        {
            Validator.ArgumentNullExceptionString(username, ErrorMessages.InvalidUsername);
            Validator.ArgumentNullExceptionString(connectionId,ErrorMessages.InvalidConnectionId );

            // Thread-safe access to collections
            lock (userMap)
            {
                if (!userMap.ContainsKey(username))
                {
                    userMap[username] = new HashSet<string>();
                }
                userMap[username].Add(connectionId);
            }
        }

        public HashSet<string> GetConnections(string username)
        {
            Validator.ArgumentNullExceptionString(username, ErrorMessages.InvalidUsername);

            var conn = new HashSet<string>();

            try
            {
                // Thread-safe access to collections
                lock (userMap)
                {
                    conn = userMap[username];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn = null;
            }
            return null;
        }

        public void RemoveConnection(string connectionId)
        {
            Validator.ArgumentNullExceptionString(connectionId, ErrorMessages.InvalidConnectionId);

            // Thread-safe access to collections
            lock (userMap)
            {
                foreach (var username in userMap.Keys)
                {
                    if (userMap.ContainsKey(username))
                    {
                        if (userMap[username].Contains(connectionId))
                        {
                            userMap[username].Remove(connectionId);
                            break;
                        }
                    }
                }
            }
        }
    }
}