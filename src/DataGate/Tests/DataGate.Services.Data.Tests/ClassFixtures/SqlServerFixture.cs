// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ClassFixtures
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.InputModels.Funds;
    using DataGate.Web.ViewModels;

    public class SqlServerFixture : IDisposable
    {
        public SqlServerFixture()
        {
            ExecuteSqlFile("create.sql");
            AutoMapperConfig.RegisterMappings(
               typeof(ErrorViewModel).GetTypeInfo().Assembly,
               typeof(EditFundInputModel).GetTypeInfo().Assembly);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ExecuteSqlFile("drop.sql");
            }
        }

        private static void ExecuteSqlFile(string fileName)
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
    }
}