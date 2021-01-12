// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.SqlClient
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Services.Tests.TestData;
    using DataGate.Web.Dtos.Entities;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Infrastructure.Extensions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;
    using Xunit.Abstractions;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class SqlQueryManagerTests
    {
        private readonly ITestOutputHelper output;
        private readonly SqlServerFixture fixture;
        private readonly ISqlQueryManager sqlQueryManager;

        public SqlQueryManagerTests(
            ITestOutputHelper output,
            SqlServerFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
            this.sqlQueryManager = this.fixture.ServiceProvider.GetRequiredService<ISqlQueryManager>();
        }

        [Fact]
        public void Connection_ShouldConnectToTestDatabase()
        {
            Assert.True(this.fixture.Context.Database.IsSqlServer());
            Assert.True(this.fixture.Context.Database.CanConnect());
        }

        #region ExecuteQueryAsync

        [Fact]
        public void ExecuteQuery_FnAllFundWithValidDate_ShouldReturnResultSet()
        {
            var result = this.sqlQueryManager
                .ExecuteQueryAsync(SqlFunctionDictionary.AllFund, DateTime.Now)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 15);
            Assert.True(result[0].Length == 20);

            TestsHelper.PrintTableOutput(this.output, SqlFunctionDictionary.AllFund, result);
        }

        [Fact]
        public void ExecuteQuery_FnAllSubFundWithValidDate_ShouldReturnResultSet()
        {
            var result = this.sqlQueryManager
                .ExecuteQueryAsync(SqlFunctionDictionary.AllSubFund, DateTime.Now)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 78);
            Assert.True(result[0].Length == 31);

            TestsHelper.PrintTableOutput(this.output, SqlFunctionDictionary.AllSubFund, result);
        }

        [Fact]
        public void ExecuteQuery_FnAllShareClassWithValidDate_ShouldReturnResultSet()
        {
            var result = this.sqlQueryManager
                .ExecuteQueryAsync(SqlFunctionDictionary.AllShareClass, DateTime.Now)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 254);
            Assert.True(result[0].Length == 28);

            TestsHelper.PrintTableOutput(this.output, SqlFunctionDictionary.AllShareClass, result);
        }

        [Theory]
        [InlineData(SqlFunctionDictionary.AllFund)]
        [InlineData(SqlFunctionDictionary.AllSubFund)]
        [InlineData(SqlFunctionDictionary.AllShareClass)]
        public void ExecuteQuery_WithValidColumns_ShouldReturnResultSet(string function)
        {
            string[] columns = new[] { "ID", "NAME" };

            var result = this.sqlQueryManager
                .ExecuteQueryAsync(function, DateTime.Now, null, columns)
                .ToListAsync()
                .Result;

            Assert.True(result[0].Length == 2);
            Assert.Contains(result[0], a => a == columns[0]);
            Assert.Contains(result[0], a => a == columns[1]);

            TestsHelper.PrintTableOutput(this.output, function, result);
        }

        [Theory]
        [InlineData(SqlFunctionDictionary.AllFund)]
        [InlineData(SqlFunctionDictionary.AllSubFund)]
        [InlineData(SqlFunctionDictionary.AllShareClass)]
        public void ExecuteQuery_WithOldDate_ShouldReturnEmptyResultSetWithHeaders(string function)
        {
            var result = this.sqlQueryManager
                .ExecuteQueryAsync(function, DateTime.Now.AddYears(-50))
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 1);

            TestsHelper.PrintTableOutput(this.output, function, result);
        }

        [Theory]
        [ClassData(typeof(InvalidSqlDataGenerator))]
        public void ExecuteQuery_WithInvalidDataAndNullId_ShouldThrowAnException(
            string function, DateTime? date, IEnumerable<string> columns)
        {
            Action act = () =>
            {
                var result = this.sqlQueryManager
                    .ExecuteQueryAsync(function, date, null, columns)
                    .ToListAsync()
                    .Result;
            };

            Assert.Throws<SqlException>(act);
        }

        [Fact]
        public void ExecuteQuery_ById_WithValidData_ShouldReturnOneRow()
        {
            var result = this.sqlQueryManager
                .ExecuteQueryAsync(SqlFunctionDictionary.ByIdShareClass, DateTime.Now, 1)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 2);
            Assert.True(result[0].Length == 28);

            TestsHelper.PrintTableOutput(this.output, SqlFunctionDictionary.ByIdShareClass, result);
        }

        [Fact]
        public void ExecuteQuery_ById_WithValidDataAndNonExistingId_EmptyResultSet()
        {
            var result = this.sqlQueryManager
                .ExecuteQueryAsync(SqlFunctionDictionary.ByIdShareClass, DateTime.Now, 5000)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 1);
            Assert.True(result[0].Length == 28);

            TestsHelper.PrintTableOutput(this.output, SqlFunctionDictionary.ByIdShareClass, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(null)]
        public void ExecuteQuery_ById_WithValidDataAndUnvalidId_ThrowsSqlException(int? id)
        {
            Action act = () =>
            {
                var result = this.sqlQueryManager
                    .ExecuteQueryAsync(SqlFunctionDictionary.ByIdShareClass, DateTime.Now, id)
                    .ToListAsync()
                    .Result;
            };

            Assert.Throws<SqlException>(act);
        }

        #endregion

        #region ExecuteQueryTimeSeriesAsync

        [Fact]
        public void ExecuteQueryTimeSeriesAsync_SqlCommand_ShouldReturnResultSet()
        {
            const string functionName = "select * from tb_timeseries_shareclass";

            var result = this.sqlQueryManager
                .ExecuteQueryTimeSeriesAsync(functionName)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 28);
            Assert.True(result[0].Length == 6);

            TestsHelper.PrintTableOutput(this.output, functionName, result);
        }

        [Fact]
        public void ExecuteQueryTimeSeriesAsync_WithNonExistingCommand_ShouldThrowAnException()
        {
            Action act = () =>
            {
                const string functionName = "Not a SQL command";

                var result = this.sqlQueryManager
                    .ExecuteQueryTimeSeriesAsync(functionName)
                    .Take(100)
                    .ToListAsync()
                    .Result;
            };

            Assert.Throws<SqlException>(act);
        }

        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData(null)]
        public void ExecuteQueryTimeSeriesAsync_WithUnvalidData_ShouldThrowAnException(string command)
        {
            Action act = () =>
            {
                var result = this.sqlQueryManager
                    .ExecuteQueryTimeSeriesAsync(command)
                    .Take(100)
                    .ToListAsync()
                    .Result;
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        #endregion

        #region ExecuteQueryReportsAsync

        [Fact]
        public void ExecuteQueryReportsAsync_FunctionName_ShouldReturnResultSet()
        {
            var result = this.sqlQueryManager
                .ExecuteQueryReportsAsync(SqlFunctionDictionary.ReportFunds, DateTime.Now)
                .ToListAsync()
                .Result;

            Assert.True(result.Count == 13);
            Assert.True(result[0].Length == 3);

            TestsHelper.PrintTableOutput(this.output, SqlFunctionDictionary.ReportFunds, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("           ")]
        [InlineData(null)]
        public void ExecuteQueryReportsAsync_EmptyFunctionName_ShouldThrowAnException(string functionName)
        {
            Action act = () =>
            {
                var result = this.sqlQueryManager
                    .ExecuteQueryReportsAsync(functionName, DateTime.Now)
                    .ToListAsync()
                    .Result;
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("NOT_A_FUNCTION")]
        [InlineData("NOT A FUNCTION")]
        public void ExecuteQueryReportsAsync_NotAFunctionName_ShouldThrowAnException(string functionName)
        {
            Action act = () =>
            {
                var result = this.sqlQueryManager
                    .ExecuteQueryReportsAsync(functionName, DateTime.Now)
                    .ToListAsync()
                    .Result;
            };

            Assert.Throws<SqlException>(act);
        }

        [Theory]
        [InlineData(SqlFunctionDictionary.ReportFunds, "2020-12-01", 13, 3)]
        [InlineData(SqlFunctionDictionary.ReportFunds, "1020-01-01", 1, 0)]
        [InlineData(SqlFunctionDictionary.ReportSubFunds, "2020-11-01", 62, 9)]
        [InlineData(SqlFunctionDictionary.ReportSubFunds, "1020-01-01", 1, 9)]
        public void ExecuteQueryReportsAsync_FunctionNameAndDate_ShouldReturnResultSet(string functionName, string date, int expectedCount, int expectedHeaderCount)
        {
            var result = this.sqlQueryManager
                .ExecuteQueryReportsAsync(functionName, DateTime.Parse(date))
                .ToListAsync()
                .Result;

            Assert.Equal(expectedCount, result.Count);
            Assert.Equal(expectedHeaderCount, result[0].Length);

            TestsHelper.PrintTableOutput(this.output, functionName, result);
        }

        #endregion

        #region ExecuteProcedure

        [Fact]
        public void ExecuteProcedure_WithValidData_ShouldReturnResultSet()
        {
            SqlCommand command = this.fixture.Connection.CreateCommand();

            command.CommandText = "getAuM_fund_test @datereport";

            command.Parameters.Add(new SqlParameter("@datereport", SqlDbType.NVarChar)
            {
                Value = DateTimeExtensions.ToSqlFormat(DateTime.Now)
            });

            var result = SqlHelper.ExecuteCommand(command).ToListAsync().Result;

            Assert.True(result.Count == 13);
            Assert.True(result[0].Length == 3);

            TestsHelper.PrintTableOutput(this.output, "getAuM_fund_test", result);
        }

        [Theory]
        [InlineData("Dummy text")]
        [InlineData("")]
        [InlineData(null)]
        public void ExecuteProcedure_NotAProcedureName_ThrowsAnException(string procName)
        {
            Action act = () =>
            {
                SqlCommand command = new SqlCommand();
                command.Parameters.Add("@procedure", SqlDbType.NVarChar).Value = procName;
                command.CommandText = "@procedure";

                var sqlDate = DateTimeExtensions.ToSqlFormat(DateTime.Now);

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter("@datereport", SqlDbType.NVarChar) {Value = sqlDate}
                });

                this.sqlQueryManager.ExecuteProcedure(command).Wait();
            };

            Assert.Throws<AggregateException>(act);
        }

        [Theory]
        [InlineData(SqlDbType.Int, 1)]
        [InlineData(SqlDbType.NVarChar, "text")]
        [InlineData(SqlDbType.DateTime, "")]
        [InlineData(SqlDbType.DateTime, "       ")]
        public void ExecuteProcedure_InvalidParameter_ThrowsAnException(SqlDbType type, object value)
        {
            Action act = () =>
            {
                string procName = "getAuM_fund_test @datereport";
                SqlCommand command = new SqlCommand();
                command.Parameters.Add("@procedure", SqlDbType.NVarChar).Value = procName;
                command.CommandText = "@procedure";

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter("@datereport", type) {Value = value}
                });

                this.sqlQueryManager.ExecuteProcedure(command).Wait();
            };

            Assert.Throws<AggregateException>(act);
        }

        #endregion

        #region ExecuteQueryMapping

        [Fact]
        public void ExecuteQueryMapping_WithId_ShouldReturnResultSet()
        {
            var dto = this.sqlQueryManager.ExecuteQueryMapping<CountryDistDto>(
                SqlFunctionDictionary.CountryDistShareClass,
                94);

            Assert.True(dto != null && dto.ToList().Count > 0);
        }

        [Fact]
        public void ExecuteQueryMapping_WithIdAndDate_ShouldReturnResultSet()
        {
            var dto = this.sqlQueryManager.ExecuteQueryMapping<EditFundGetDto>(
                SqlFunctionDictionary.ByIdFund,
                1,
                DateTime.Now);

            Assert.True(dto != null && dto.ToList().Count > 0);
        }

        #endregion
    }
}
