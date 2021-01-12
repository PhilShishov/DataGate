// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ClassFixtures
{
    using System;
    using System.Data.SqlClient;
    using System.Reflection;

    using DataGate.Common;
    using DataGate.Data;
    using DataGate.Services.Mapping;
    using DataGate.Web.InputModels.Funds;
    using DataGate.Web.ViewModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class SqlServerFixture : IDisposable
    {
        public SqlServerFixture()
        {
            TestsHelper.ExecuteSqlFile("create.sql");

            var services = new ServiceCollection()
                            .AddEntityFrameworkSqlServer();

            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile($"testsettings.json", optional: false);
            var config = configBuilder.Build();

            services.AddSingleton<IConfiguration>(config);

            this.Configuration = config;

            this.ServiceProvider = services.BuildServiceProvider();

            CreateContextForSqlServer(config);

            AutoMapperConfig.RegisterMappings(
               typeof(ErrorViewModel).GetTypeInfo().Assembly,
               typeof(EditFundInputModel).GetTypeInfo().Assembly);
        }

        public ApplicationDbContext Context { get; private set; }

        public SqlConnection Connection { get; private set; }

        public IConfiguration Configuration { get; private set; }

        public ServiceProvider ServiceProvider { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                TestsHelper.ExecuteSqlFile("drop.sql");
                this.Context.Dispose();
                this.Connection.Close();
            }
        }

        private void CreateContextForSqlServer(IConfigurationRoot config)
        {
            this.Connection = new SqlConnection(config.GetConnectionString(GlobalConstants.DataGateAppConnection));
            this.Connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(this.Connection)
                .Options;
            this.Context = new ApplicationDbContext(options);
        }
    }
}