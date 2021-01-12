// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.Factories
{
    using System;

    using DataGate.Data;

    using Microsoft.EntityFrameworkCore;

    public static class ConnectionFactory
    {
        public static UsersDbContext CreateContextForInMemory()
        {
            var options = new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UsersDbContext(options);
        }
    }
}
