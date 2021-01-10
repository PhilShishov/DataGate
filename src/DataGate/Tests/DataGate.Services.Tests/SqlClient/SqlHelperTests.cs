namespace DataGate.Services.Tests.SqlClient
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.SqlClient;

    using Microsoft.Extensions.Configuration;

    using Xunit;
    using Xunit.Abstractions;

    public class SqlHelperTests : SqlServerContextProvider, IDisposable
    {
        private readonly ITestOutputHelper output;
        private readonly SqlConnection connection;
        private readonly SqlCommand command;

        public SqlHelperTests(ITestOutputHelper output)
        {
            this.output = output;
            this.connection = new SqlConnection();
            this.connection.ConnectionString = base.Configuration.GetConnectionString(GlobalConstants.DataGateAppConnection);
            this.connection.Open();
            this.command = this.connection.CreateCommand();
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
                this.command.Dispose();
                this.connection.Close();
                //base.Context?.Dispose();
            }
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
        public void ExecuteCommand_NullSqlCommand_ShouldThrowAnException()
        {
            Action act = () =>
            {
                var result = SqlHelper.ExecuteCommand(null).ToListAsync().Result;
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void ExecuteCommand_WithInvalidCommandText_ShouldThrowAnException(string text)
        {
            Action act = () =>
            {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                this.command.CommandText = text;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities

                var result = SqlHelper.ExecuteCommand(this.command).ToListAsync().Result;
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ExecuteCommand_NotACommand_ShouldThrowAnException()
        {
            Action act = () =>
            {
                this.command.CommandText = "NOT A COMMAND";

                var result = SqlHelper.ExecuteCommand(command).ToListAsync().Result;
            };

            Assert.Throws<SqlException>(act);
        }
    }
}
