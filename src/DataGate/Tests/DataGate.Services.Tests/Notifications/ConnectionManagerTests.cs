// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Notifications;

    using Xunit;

    public class ConnectionManagerTests
    {
        private readonly ConnectionManager connectionManager;
        private static readonly Dictionary<string, HashSet<string>> userMap =
            new Dictionary<string, HashSet<string>>();

        public ConnectionManagerTests()
        {
            this.connectionManager = new ConnectionManager();
        }

        [Fact]
        public void AddConnection_Lock_WithValidData_ShouldAddToMap()
        {
            var username = "test";
            var connectionId = "1234";

            lock (userMap)
            {
                if (!userMap.ContainsKey(username))
                {
                    userMap[username] = new HashSet<string>();
                }
                userMap[username].Add(connectionId);
            }
            Assert.Single(userMap);
        }

        [Theory]
        [InlineData("", "1234")]
        [InlineData("     ", "1234")]
        [InlineData(null, "1234")]
        [InlineData("test", "")]
        [InlineData("test", "       ")]
        [InlineData("test", null)]
        public void AddConnection_WithInvalidData_ShouldThrowException(string username, string connectionId)
        {
            Action act = () => this.connectionManager.AddConnection(username, connectionId);

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void RemoveConnection_Lock_WithValidData_ShouldRemoveFromMap()
        {
            Assert.Empty(userMap);
            var user = "test";
            var connectionId = "1234";

            lock (userMap)
            {
                if (!userMap.ContainsKey(user))
                {
                    userMap[user] = new HashSet<string>();
                }
                userMap[user].Add(connectionId);
            }

            Assert.Single(userMap[user]);
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

            Assert.Empty(userMap[user]);
        }
    }
}