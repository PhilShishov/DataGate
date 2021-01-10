// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests
{
    using System.IO;
    using System.Text.RegularExpressions;

    using DataGate.Data;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Services.Tests.Factories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class SqlServerContextProvider : IClassFixture<SqlQueryManagerFixture>
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IConfiguration Configuration;
        protected readonly ServiceProvider ServiceProvider;

        public SqlServerContextProvider()
        {
            var services = new ServiceCollection()
                .AddEntityFrameworkSqlServer();

            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile($"testsettings.json", optional: false);
            var config = configBuilder.Build();

            services.AddSingleton<IConfiguration>(config);
            services.AddScoped<ISqlQueryManager, SqlQueryManager>();

            this.ServiceProvider = services.BuildServiceProvider();
            this.Configuration = config;

            this.Context = ConnectionFactory.CreateContextForSqlServer(this.Configuration);
        }

        public void ExecuteSqlFile(string fileName)
        {
            var script = File.ReadAllText(fileName);
            var parts = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase); ;
            foreach (var part in parts)
            {
                if (!string.IsNullOrWhiteSpace(part.Trim()))
                {
                    this.Context.Database.ExecuteSqlRaw(part);
                }
            }
        }
    }
}
