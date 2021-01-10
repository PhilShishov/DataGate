// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Storage
{
    using System;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Services.Data.Storage;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Web.InputModels.ShareClasses;

    using Xunit;

    public class ShareClassStorageServiceTests : SqlServerContextProvider
    {
        private readonly ShareClassStorageService service;
        private const string CorrectShareClassName = "Efficiency Growth Fund - Euro Global Bond I EUR"; 

        public ShareClassStorageServiceTests()
        {
            this.service = ShareClassStorageServiceTestData.CreateService(base.Context, base.Configuration);
        }

        [Fact]
        public async Task Create_ShareClass_MissingParameters_ShouldThrowException()
        {
                Func<Task> task = async () => await this.service.Create(this.SetShareClass());
                await Assert.ThrowsAsync<CustomSqlException>(task);
        }

        [Fact]
        public async Task Create_ShareClass_ShouldReturnShareClassId()
        {
            var shareclass = this.SetShareClass();

            await using (base.Context)
            {
                var existing = this.service.ByIdAndDate<EditShareClassInputModel>(1, "2019-01-01");
                var actual = await this.service.Create(shareclass);
                Assert.True(actual > 0);
            }
        }

        [Fact]
        public async Task Update_ShareClass_ShouldUpdateEntity()
        {
            await using (base.Context)
            {
                var existing = this.service.ByIdAndDate<EditShareClassInputModel>(1, "2019-01-01");
                existing.CommentTitle = "Updated";
                var updatedSubFundId = await this.service.Edit(existing);
                Assert.True(updatedSubFundId > 0);
            }
        }

        [Fact]
        public async Task DoesExist_WithValidData_ShouldReturnTrue()
        {
            bool result = await this.service.DoesExist(CorrectShareClassName);
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData("Invalid")]
        [InlineData(null)]
        public async Task DoesExist_WithInvalidData_ShouldThrowException(string shareClassName)
        {
            bool task = await this.service.DoesExist(shareClassName);
            Assert.False(task);
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
            Func<Task> task = async () => await this.service.DoesExistAtDate(shareClassName, DateTime.Parse(initialDate));
            await Assert.ThrowsAsync<SqlTypeException>(task);
        }

        [Theory]
        [InlineData(1, "2011-07-14")]
        [InlineData(2, "2011-07-14")]
        public void ByIdAndDate_WithValidData_ShouldReturnObject(int id, string date)
        {
            var result = this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ShareClassName));
            Assert.True(result.ShareClassName.Substring(0, 20) == CorrectShareClassName.Substring(0, 20));
        }

        [Theory]
        [InlineData(1, "1800-01-01")]
        public void ByIdAndDate_WithInvalidData_ShouldReturnNull(int id, string date)
        {
            var result = this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.Null(result);
        }

        [Theory]
        [InlineData(-1, "2011-07-14")]
        public void ByIdAndDate_WithInvalidData_ThrowsException(int id, string date)
        {
            void Task() => this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.Throws<EntityNotFoundException>((Action) Task);
        }

        private CreateShareClassInputModel SetShareClass()
        {
            return ShareClassStorageServiceTestData.GenerateDocument();
        }
    }
}
