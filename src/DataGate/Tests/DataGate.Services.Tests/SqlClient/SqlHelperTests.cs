namespace DataGate.Services.Tests.SqlClient
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.SqlClient;
    using DataGate.Web.Infrastructure.Extensions;

    using Microsoft.Extensions.Configuration;

    using Xunit;
    using Xunit.Abstractions;

    public class SqlHelperTests : SqlServerContextProvider
    {
        private readonly ITestOutputHelper output;

        public SqlHelperTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ExecuteSQLCommand_GetDateText_ShouldReturnServerDate()
        {
            using var connection = new SqlConnection
            {
                ConnectionString = this.Configuration.GetConnectionString(GlobalConstants.DataGateAppConnection)
            };

            connection.Open();
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "select GETDATE()";

            var result = SqlHelper.GetStringDataAsync(command).ToListAsync().Result;

            Assert.True(result.Count == 2);
            Assert.True(result[1].Length == 1);
            var currentDateStr = result[1][0].ToString();
            var dt = DateTime.Parse(currentDateStr ?? string.Empty);
            Assert.True(dt < DateTime.Now);
            TestsHelper.PrintTableOutput(this.output, "GetDate", result);
            connection.Close();
        }

        [Fact]
        public void ExecuteCommand_Null_ShouldThrowAnException()
        {
            Action act = () =>
            {
                using var connection = new SqlConnection
                {
                    ConnectionString = this.Configuration.GetConnectionString(GlobalConstants.DataGateAppConnection)
                };

                connection.Open();

                var result = SqlHelper.GetStringDataAsync(null).ToListAsync().Result;

                connection.Close();
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ExecuteCommand_Empty_ShouldThrowAnException()
        {
            Action act = () =>
            {
                using var connection = new SqlConnection
                {
                    ConnectionString = this.Configuration.GetConnectionString(GlobalConstants.DataGateAppConnection)
                };

                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = string.Empty;

                var result = SqlHelper.GetStringDataAsync(command).ToListAsync().Result;

                connection.Close();
            };

            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void ExecuteCommand_NotACommand_ShouldThrowAnException()
        {
            Action act = () =>
            {
                using var connection = new SqlConnection
                {
                    ConnectionString = this.Configuration.GetConnectionString(GlobalConstants.DataGateAppConnection)
                };

                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "NOT A COMMAND";

                var result = SqlHelper.GetStringDataAsync(command).ToListAsync().Result;

                connection.Close();
            };

            Assert.Throws<SqlException>(act);
        }
    }
}
