// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.ClassFixtures
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
            this.ExecuteSqlFile("create.sql");
            AutoMapperConfig.RegisterMappings(
               typeof(ErrorViewModel).GetTypeInfo().Assembly,
               typeof(EditFundInputModel).GetTypeInfo().Assembly);
        }

        public void Dispose()
        {
            this.ExecuteSqlFile("drop.sql");
        }

        private void ExecuteSqlFile(string fileName)
        {
            var connection = new SqlConnection(GlobalConstants.SqlServerConnectionWithoutDb);
            connection.Open();

            var script = File.ReadAllText(fileName);
            var parts = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase); ;
            foreach (var part in parts)
            {
                if (!string.IsNullOrWhiteSpace(part.Trim()))
                {
                    using (var command = new SqlCommand(part, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}