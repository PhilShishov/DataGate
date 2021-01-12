// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.SqlClient
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.SqlClient;
    using DataGate.Services.Tests.ClassFixtures;

    using Xunit;
    using Xunit.Abstractions;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class SqlHelperTests
    {
        private readonly ITestOutputHelper output;
        private readonly SqlCommand command;

        public SqlHelperTests(
            ITestOutputHelper output,
            SqlServerFixture fixture)
        {
            this.output = output;
            this.command = fixture.Connection.CreateCommand();
        }

        [Fact]
        public void ExecuteCommand_ShouldReturnResult()
        {
            this.command.CommandText = "select GETDATE()";

            var result = SqlHelper.ExecuteCommand(command).ToListAsync().Result;

            Assert.True(result.Count == 2);
            Assert.True(result[1].Length == 1);
            var currentDateStr = result[1][0].ToString();
            var dt = DateTime.Parse(currentDateStr ?? string.Empty);
            Assert.True(dt < DateTime.Now);
            TestsHelper.PrintTableOutput(this.output, "GetDate", result);
        }

        [Fact]
        public async Task ExecuteCommand_NullSqlCommand_ShouldThrowAnException()
        {
            async Task task() => await SqlHelper.ExecuteCommand(null).ToListAsync();

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public async Task ExecuteCommand_WithInvalidCommandText_ShouldThrowAnException(string text)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            this.command.CommandText = text;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            async Task task() => await SqlHelper.ExecuteCommand(this.command).ToListAsync();

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        [Fact]
        public async Task ExecuteCommand_NotACommand_ShouldThrowAnException()
        {
            this.command.CommandText = "NOT A COMMAND";
            async Task task() => await SqlHelper.ExecuteCommand(this.command).ToListAsync();

            await Assert.ThrowsAsync<SqlException>(task);
        }
    }
}
