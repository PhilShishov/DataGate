// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Storage
{
    using System;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Services.Data.Storage;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Web.InputModels.ShareClasses;

    using Xunit;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class ShareClassStorageServiceTests
    {
        private readonly CreateShareClassInputModel testData;
        private readonly ShareClassStorageService service;
        private readonly SqlServerFixture fixture;
        private const string CorrectShareClassName = "Efficiency Growth Fund - Euro Global Bond I EUR";

        public ShareClassStorageServiceTests(SqlServerFixture fixture)
        {
            this.testData = ShareClassStorageTestData.Generate();
            this.service = ShareClassStorageTestData.CreateService(fixture.Context, fixture.Configuration);
            this.fixture = fixture;
        }

        [Fact]
        public async Task Create_ShareClass_EmptyModel_ShouldThrowException()
        {
            async Task task() => await this.service.Create(null);
            await Assert.ThrowsAsync<NullReferenceException>(task);
        }

        [Fact]
        public async Task Create_ShareClass_ShouldIncreaseCountAndReturnContainerId()
        {
            var count = this.fixture.Context.TbHistoryShareClass.Count();
            var containerId = await this.service.Create(this.testData);

            Assert.True(containerId > 0);
            Assert.Equal(count + 1, this.fixture.Context.TbHistoryShareClass.Count());
        }

        [Fact]
        public async Task Update_ShareClass_EmptyModel_ShouldThrowException()
        {
            async Task task() => await this.service.Edit(null);
            await Assert.ThrowsAsync<NullReferenceException>(task);
        }

        [Fact]
        public async Task Update_ShareClass_ShouldUpdateEntityAndReturnId()
        {
            var shareclass = this.service.ByIdAndDate<EditShareClassInputModel>(1, "2020-01-01");
            shareclass.CommentTitle = "Updated";
            shareclass.InitialDate = DateTime.Now;

            var scId = await this.service.Edit(shareclass);
            Assert.True(scId == shareclass.Id);
        }

        [Fact]
        public async Task DoesExist_WithValidData_ShouldReturnTrue()
        {
            Assert.True(await this.service.DoesExist(CorrectShareClassName));
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData("Invalid")]
        [InlineData(null)]
        public async Task DoesExist_WithInvalidData_ShouldThrowException(string shareClassName)
        {
            Assert.False(await this.service.DoesExist(shareClassName));
        }

        [Fact]
        public async Task DoesExistAtDate_WithValidData_ShouldReturnTrue()
        {
            DateTime initialDate = DateTime.Parse("2011-07-14 00:00:00.000");
            bool result = await this.service.DoesExistAtDate(CorrectShareClassName, initialDate);
            Assert.True(result);
        }

        [Theory]
        [InlineData("", "2020-01-01")]
        [InlineData("       ", "2020-01-01")]
        [InlineData("Invalid", "2020-01-01")]
        [InlineData(null, "2020-01-01")]
        [InlineData(CorrectShareClassName, "1754-01-01")]
        public async Task DoesExistAtDate_WithInvalidData_ShouldReturnFalse(string shareClassName, string initialDate)
        {
            bool result = await this.service.DoesExistAtDate(shareClassName, DateTime.Parse(initialDate));
            Assert.False(result);
        }

        [Theory]
        [InlineData("Invalid", "0001-01-01")]
        [InlineData(CorrectShareClassName, "0001-01-01")]
        public async Task DoesExistAtDate_WithInvalidData_ShouldThrowException(string shareClassName, string initialDate)
        {
            async Task task() => await this.service
            .DoesExistAtDate(shareClassName, DateTime.Parse(initialDate));
            await Assert.ThrowsAsync<SqlTypeException>(task);
        }

        [Theory]
        [InlineData(1, "2019-07-14")]
        [InlineData(2, "2019-07-14")]
        public void ByIdAndDate_WithValidData_ShouldReturnEntity(int id, string date)
        {
            var result = this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ShareClassName));
            Assert.True(result.ShareClassName.Substring(0, 20) == CorrectShareClassName.Substring(0, 20));
        }

        [Theory]
        [InlineData(1, "1950-01-01")]
        public void ByIdAndDate_WithInvalidDate_ShouldReturnNull(int id, string date)
        {
            var result = this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.Null(result);
        }

        [Theory]
        [InlineData(-1, "2011-07-14")]
        public void ByIdAndDate_WithInvalidId_ThrowsException(int id, string date)
        {
            void Task() => this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.Throws<EntityNotFoundException>((Action)Task);
        }
    }
}
