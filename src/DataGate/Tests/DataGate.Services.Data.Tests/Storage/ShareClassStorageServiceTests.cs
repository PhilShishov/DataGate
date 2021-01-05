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

    public class ShareClassStorageServiceTests : SqlServerContextProvider /*IDisposable*/
    {
        private readonly ShareClassStorageService service;
        private const string CorrectShareClassName = "Efficiency Growth Fund - Euro Global Bond I EUR"; 

        public ShareClassStorageServiceTests()
        {
            this.service = ShareClassStorageServiceTestData.CreateService(base.Context, base.Configuration);
        }

        //public void Dispose()
        //{
        //}

        [Fact]
        public async Task Create_ShareClass_ShouldReturnSubFundId()
        {
            var document = this.SetDocumentValues();

            await using (base.Context)
            {
                var newSubFundId = await this.service.Create(document);

                Assert.True(newSubFundId > 0);
            }
        }

        [Fact]
        public async Task DoesExist_WithCorrectAgrType_ShouldReturnTrue()
        {
            bool result = await this.service.DoesExist(CorrectShareClassName);
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData("Invalid")]
        [InlineData(null)]
        public async Task DoesExist_WithInvalidAgrType_ShouldThrowException(string shareClassName)
        {
            bool task = await this.service.DoesExist(shareClassName);
            Assert.False(task);
        }

        [Fact]
        public async Task DoesExistAtDate_WithCorrectAgrType_ShouldReturnTrue()
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
        public async Task DoesExistAtDate_WithInvalidAgrType_ShouldReturnFalse(string shareClassName, string initialDate)
        {
            bool result = await this.service.DoesExistAtDate(shareClassName, DateTime.Parse(initialDate));
            Assert.False(result);
        }

        [Theory]
        [InlineData("Invalid", "0001-01-01")]
        [InlineData(CorrectShareClassName, "0001-01-01")]
        public async Task DoesExistAtDate_WithInvalidAgrType_ShouldThrowException(string shareClassName, string initialDate)
        {
            Func<Task> task = async () => await this.service.DoesExistAtDate(shareClassName, DateTime.Parse(initialDate));
            await Assert.ThrowsAsync<SqlTypeException>(task);
        }

        [Theory]
        [InlineData(1, "2011-07-14")]
        [InlineData(2, "2011-07-14")]
        public void ByIdAndDate_WithCorrectAgrType_ShouldReturnObject(int id, string date)
        {
            var result = this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.ShareClassName));
            Assert.True(result.ShareClassName.Substring(0, 20) == CorrectShareClassName.Substring(0, 20));
        }

        [Theory]
        [InlineData(1, "1800-01-01")]
        public void ByIdAndDate_WithIncorrectAgrType_ShouldReturnNull(int id, string date)
        {
            var result = this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            Assert.Null(result);
        }

        [Theory]
        [InlineData(-1, "2011-07-14")]
        public async Task ByIdAndDate_WithIncorrectAgrType_ThrowsException(int id, string date)
        {
            Func<Task> task = async () => this.service.ByIdAndDate<EditShareClassInputModel>(id, date);
            await Assert.ThrowsAsync<EntityNotFoundException>(task);
        }

        private CreateShareClassInputModel SetDocumentValues()
        {
            return ShareClassStorageServiceTestData.GenerateDocument();
        }
    }
}
