// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Web.Helpers;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Queries;

    using Xunit;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class EntitiesServiceTests
    {
        private readonly EntityService service;
        private AllSelectedDto dto;

        public EntitiesServiceTests(SqlServerFixture fixture)
        {
            this.service = EntityServiceTestData.CreateService(fixture.Context, fixture.Configuration);
        }

        [Theory]
        [InlineData("2020-01-01", 11)]
        [InlineData("1800-01-01", 0)]
        public async Task All_Fund_ShouldReturnCorrectResult(string date, int expectedCount)
        {
            var dt = DateTimeExtensions.FromWebFormat(date);
            var result = await this.service
                .All(SqlFunctionDictionary.AllFund, null, dt, 1)
                .ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedCount);
        }

        [Fact]
        public async Task All_Fund_WrongDate_ShouldThrowException()
        {
            async Task task()
            {
                await this.service
                .All(SqlFunctionDictionary.AllFund, null, null, 0)
                .ToListAsync();
            }

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(task);
        }

        [Fact]
        public async Task All_Fund_WrongFunction_ShouldThrowException()
        {
            async Task task()
            {
                await this.service
                .All("NotAFunction", null, null, 0)
                .ToListAsync();
            }

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(task);
        }

        [Theory]
        [InlineData("2020-01-01", 74)]
        [InlineData("1800-01-01", 0)]
        public async Task All_SubFund_ShouldReturnEntities(string date, int expectedCount)
        {
            var dt = DateTimeExtensions.FromWebFormat(date);
            var result = await this.service
                .All(SqlFunctionDictionary.AllSubFund, null, dt, 1)
                .ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedCount);
        }

        [Theory]
        [InlineData("2020-01-01", 241)]
        [InlineData("1800-01-01", 0)]
        public async Task All_ShareClass_ShouldReturnEntities(string date, int expectedCount)
        {
            var dt = DateTimeExtensions.FromWebFormat(date);
            var result = await this.service
                .All(SqlFunctionDictionary.AllShareClass, null, dt, 1)
                .ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedCount);
        }

        [Theory]
        [InlineData(14, 5)]
        public async Task AllSelected_Fund_ShouldReturnCorrectResult(int expectedCount, int expectedHeaders)
        {
            this.dto = await EntityServiceTestData.Generate(this.service, SqlFunctionDictionary.AllFund);
            var result = await this.service.AllSelected(SqlFunctionDictionary.AllFund, this.dto, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedCount);
            Assert.True(result[0].Length == expectedHeaders);
        }

        [Fact]
        public async Task AllSelected_Fund_WrongFunction_ShouldThrowException()
        {
            this.dto = await EntityServiceTestData.Generate(this.service, SqlFunctionDictionary.AllFund);

            async Task task()
            {
                await this.service.AllSelected("NotAFunction", this.dto, 0).ToListAsync();
            }

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(task);
        }

        [Fact]
        public async Task AllSelected_Fund_WrongColumn_ShouldThrowException()
        {
            this.dto = await EntityServiceTestData.Generate(this.service, SqlFunctionDictionary.AllFund);

            var result = this.dto.SelectedColumns.ToList();
            result.Add("NOTACOLUMN");

            this.dto.SelectedColumns = result;

            async Task task()
            {
                await this.service.AllSelected(SqlFunctionDictionary.AllFund, this.dto, 0).ToListAsync();
            }

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(task);
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

            async Task task()
            {
                await this.service.AllSelected("NotAFunction", dtoSelected, 0).ToListAsync();
            }

            await Assert.ThrowsAsync<System.ArgumentNullException>(task);
        }

        [Fact]
        public async Task AllSelected_Fund_WrongArgumentAllSelected_ShouldThrowException()
        {
            async Task task()
            {
                _ = await this.service.AllSelected("NotAFunction", new AllSelectedDto(), 0).ToListAsync();
            }

            await Assert.ThrowsAsync<System.ArgumentNullException>(task);
        }

        [Theory]
        [InlineData(77, 5)]
        public async Task AllSelected_SubFund_ShouldReturnEntities(int expectedCount, int expectedHeaders)
        {
            this.dto = await EntityServiceTestData.Generate(this.service, SqlFunctionDictionary.AllSubFund);

            var result = await this.service.AllSelected(SqlFunctionDictionary.AllSubFund, this.dto, 1).ToListAsync();
            Assert.NotNull(result);
            Assert.True(result.Count == expectedCount);
            Assert.True(result[0].Length == expectedHeaders);
        }

        [Theory]
        [InlineData(253, 5)]
        public async Task AllSelected_ShareClass_ShouldReturnEntities(int expectedCount, int expectedHeaders)
        {
            this.dto = await EntityServiceTestData.Generate(this.service, SqlFunctionDictionary.AllShareClass);

            var result = await this.service.AllSelected(SqlFunctionDictionary.AllShareClass, this.dto, 1).ToListAsync();
            Assert.NotNull(result);
            //Assert.Equal(expectedCount, result.Count);
            Assert.Equal(expectedHeaders, result[0].Length);
        }

        [Fact]
        public async Task AllSelected_ShareClassAndColumnsWithSpace_ShouldReturnTrimmedColumns()
        {
            AllSelectedDto dto = new AllSelectedDto()
            {
                PreSelectedColumns = new[] { "STATUS   ", "    VALID FROM" },
                SelectedColumns = new[] { "         SHARE CLASS NAME             " },
                Id = 2,
                Date = DateTime.Now,
            };

            var result = await this.service
                .AllSelected(SqlFunctionDictionary.ByIdShareClass, dto, 0)
                .ToListAsync();

            Assert.Equal(2, result.Count);
            Assert.Equal(3, result[0].Length);
            Assert.Contains(result[0], a => a == dto.PreSelectedColumns.ElementAt(0).Trim());
            Assert.Contains(result[0], a => a == dto.PreSelectedColumns.ElementAt(1).Trim());
            Assert.Contains(result[0], a => a == dto.SelectedColumns.ElementAt(0).Trim());
        }
    }
}
