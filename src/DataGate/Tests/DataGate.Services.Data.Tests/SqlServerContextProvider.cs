// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests
{
    using System;
    using System.IO;

    using DataGate.Data;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.Factories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class SqlServerContextProvider : IClassFixture<MappingsProvider>
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

            this.ServiceProvider = services.BuildServiceProvider();

            this.Configuration = config;
            this.Context = ConnectionFactory.CreateContextForSqlServer(this.Configuration);
        }

        public void ExecuteSqlFile(string fileName)
        {
            var text = File.ReadAllText(fileName);
            var parts = text.Split(new string[] { "GO" }, StringSplitOptions.None);
            foreach (var part in parts)
            {
                this.Context.Database.ExecuteSqlRaw(part);
            }
        }
    }
}
