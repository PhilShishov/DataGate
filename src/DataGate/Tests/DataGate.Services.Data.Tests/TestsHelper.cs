// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests
{
    using System.Data.SqlClient;
    using System.IO;
    using System.Text.RegularExpressions;

    using DataGate.Common;
    using DataGate.Data;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public static class TestsHelper
    {
        public static void ExecuteSqlFile(string fileName)
        {
            var connection = new SqlConnection(GlobalConstants.SqlServerConnectionWithoutDb);
            connection.Open();

            var script = File.ReadAllText(fileName);
            var parts = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase); ;
            foreach (var part in parts)
            {
                if (!string.IsNullOrWhiteSpace(part.Trim()))
                {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    using (var command = new SqlCommand(part, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static ApplicationDbContext CreateContextForSqlServer(IConfiguration config)
        {
            var connection = new SqlConnection(config.GetConnectionString(GlobalConstants.DataGateAppConnection));
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connection)
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
