// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Queries;

    using Xunit;

    public class EntityServiceTests : SqlServerContextProvider
    {
        private readonly EntityService service;

        public EntityServiceTests()
        {
            this.service = EntityServiceTestData.CreateService(base.Context, base.Configuration);
        }

        [Theory]
        [InlineData("2020-01-01", 11)]
        [InlineData("1800-01-01", 0)]
        public async Task All_Fund_ShouldReturnCorrectResult(string date, int expectedAmount)
        {
            var dt = DateTimeExtensions.FromWebFormat(date);
            var result = await this.service.All(SqlFunctionDictionary.AllFund, null, dt, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedAmount);
        }

        [Theory]
        [InlineData(14, 7)]
        public async Task AllSelected_Fund_ShouldReturnCorrectResult(int expectedAmount, int expectedLength)
        {
            var headers = await service.All(SqlFunctionDictionary.AllFund, null, DateTime.Now, 0).FirstOrDefaultAsync();

            var dtoSelected = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = headers?.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                SelectedColumns = new List<string>() { "ID", "NAME", "STATUS" },
            };

            var result = await this.service.AllSelected(SqlFunctionDictionary.AllFund, dtoSelected, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedAmount);
            Assert.True(result[0].Length == expectedLength);
        }

        [Fact]
        public async Task All_Fund_WrongDate_ShouldThrowException()
        {
            Func<Task> a = async () =>
            {
                await this.service.All(SqlFunctionDictionary.AllFund, null, null, 0).ToListAsync();
            };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(a);
        }

        [Fact]
        public async Task All_Fund_WrongFunction_ShouldThrowException()
        {
            Func<Task> a = async () =>
            {
                await this.service.All("NotAFunction", null, null, 0).ToListAsync();
            };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(a);
        }

        [Fact]
        public async Task AllSelected_Fund_WrongFunction_ShouldThrowException()
        {
            var headers = await service.All(SqlFunctionDictionary.AllFund, null, DateTime.Now, 0).FirstOrDefaultAsync();

            var dtoSelected = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = headers?.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                SelectedColumns = new List<string>() { "ID", "NAME", "STATUS" },
            };

            Func<Task> a = async () =>
            {
                await this.service.AllSelected("NotAFunction", dtoSelected, 0).ToListAsync();
            };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(a);
        }

        [Fact]
        public async Task AllSelected_Fund_WrongColumn_ShouldThrowException()
        {
            var headers = await service.All(SqlFunctionDictionary.AllFund, null, DateTime.Now, 0).FirstOrDefaultAsync();

            var dtoSelected = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = headers?.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                SelectedColumns = new List<string>() { "ID", "NAME", "STATUS", "NOTACOLUMN" },
            };

            Func<Task> a = async () =>
            {
                await this.service.AllSelected(SqlFunctionDictionary.AllFund, dtoSelected, 0).ToListAsync();
            };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(a);
        }

        [Fact]
        public async Task AllSelected_Fund_WrongArgumentPreSelectedColumns_ShouldThrowException()
        {
            var dtoSelected = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = null,
                SelectedColumns = null
            };

            Func<Task> a = async () =>
            {
                await this.service.AllSelected("NotAFunction", dtoSelected, 0).ToListAsync();
            };

            await Assert.ThrowsAsync<System.ArgumentNullException>(a);
        }

        [Fact]
        public async Task AllSelected_AllFund_WrongArgumentAllSelected_ShouldThrowException()
        {
            Func<Task> a = async () =>
            {
                await this.service.AllSelected("NotAFunction", new AllSelectedDto(), 0).ToListAsync();
            };

            await Assert.ThrowsAsync<System.ArgumentNullException>(a);
        }

        [Theory]
        [InlineData("2020-01-01", 74)]
        [InlineData("1800-01-01", 0)]
        public async Task All_SubFund_ShouldReturnEntities(string date, int expectedAmount)
        {
            var dt = DateTimeExtensions.FromWebFormat(date);
            var result = await this.service.All(SqlFunctionDictionary.AllSubFund, null, dt, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedAmount);
        }

        [Theory]
        [InlineData(77, 7)]
        public async Task AllSelected_SubFund_ShouldReturnEntities(int expectedAmount, int expectedLength)
        {
            var headers = await service.All(SqlFunctionDictionary.AllSubFund, null, DateTime.Now, 0).FirstOrDefaultAsync();

            var dtoSelected = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = headers?.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                SelectedColumns = new List<string>() { "ID", "NAME", "STATUS" },
            };

            var result = await this.service.AllSelected(SqlFunctionDictionary.AllSubFund, dtoSelected, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedAmount);
            Assert.True(result[0].Length == expectedLength);
        }

        [Theory]
        [InlineData("2020-01-01", 241)]
        [InlineData("1800-01-01", 0)]
        public async Task All_ShareClass_ShouldReturnEntities(string date, int expectedAmount)
        {
            var dt = DateTimeExtensions.FromWebFormat(date);
            var result = await this.service.All(SqlFunctionDictionary.AllShareClass, null, dt, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedAmount);
        }

        [Theory]
        [InlineData(253, 7)]
        public async Task AllSelected_ShareClass_ShouldReturnEntities(int expectedAmount, int expectedLength)
        {
            var headers = await service.All(SqlFunctionDictionary.AllShareClass, null, DateTime.Now, 0).FirstOrDefaultAsync();

            var dtoSelected = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = headers?.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                SelectedColumns = new List<string>() { "ID", "NAME", "STATUS" },
            };

            var result = await this.service.AllSelected(SqlFunctionDictionary.AllShareClass, dtoSelected, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedAmount);
            Assert.True(result[0].Length == expectedLength);
        }
    }
}
