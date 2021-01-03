// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Factories
{
    using System;
    using System.Data.SqlClient;

    using DataGate.Common;
    using DataGate.Data;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public static class ConnectionFactory
    {
        public static ApplicationDbContext CreateContextForInMemory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        public static ApplicationDbContext CreateContextForSqlServer(IConfiguration configuration)
        {
            var connection = new SqlConnection(configuration.GetConnectionString(GlobalConstants.DataGateAppConnection));
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connection)
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
