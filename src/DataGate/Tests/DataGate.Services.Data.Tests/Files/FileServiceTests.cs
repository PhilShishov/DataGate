// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Files
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Services.Data.Files;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Web.InputModels.Files;

    using Xunit;

    public class FileServiceTests : SqlServerContextProvider /*IDisposable*/
    {
        private readonly FileService service;
        private readonly int tbMapFileFundCount;
        private readonly int tbSAFundCount;
        private readonly int tbFileCount;

        public FileServiceTests()
        {
            this.service = FileServiceTestData.CreateService(base.Context, base.Configuration);
            this.tbMapFileFundCount = base.Context.TbMapFilefund.Count();
            this.tbFileCount = base.Context.TbFile.Count();
            this.tbSAFundCount = base.Context.TbServiceAgreementFund.Count();
        }

        //public void Dispose()
        //{
        //}

        [Fact]
        public async Task UploadDocument_Fund_ShouldIncreaseCount()
        {
            var expectedTbMapCount = 31;
            var expectedTbFileCount = 47;

            Assert.Equal(expectedTbMapCount, this.tbMapFileFundCount);
            Assert.Equal(expectedTbFileCount, this.tbFileCount);

            var document = this.SetDocumentValues();

            using (base.Context)
            {
                await this.service.UploadDocument(document);

                Assert.Equal(expectedTbMapCount + 1, base.Context.TbMapFilefund.Count());
                Assert.Equal(expectedTbFileCount + 1, base.Context.TbFile.Count());
            }
        }

        [Theory]
        [InlineData(-5, "2020-01-01")]
        [InlineData(100, "2020-01-01")]
        [InlineData(1, "2020-01-01")]
        public async Task UploadDocument_Fund_WithUnvalidData_ShouldThrowException(int fundId, string date)
        {
            var startConnection = DateTime.Parse(date);
            var document = FileServiceTestData.GenerateDocument(fundId, startConnection);

            Func<Task> task = async () => await this.service.UploadDocument(document);

            await Assert.ThrowsAsync<CustomSqlException>(task);
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData("Invalid")]
        [InlineData(null)]
        public async Task UploadDocument_Fund_WithUnvalidDocType_ShouldThrowException(string docType)
        {
            var document = this.SetDocumentValues(docType);

            Func<Task> task = async () => await this.service.UploadDocument(document);

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        [Fact]
        public async Task UploadAgreement_Fund_ShouldIncreaseCount()
        {
            var expectedTbSAFundCount = 13;
            var expectedTbFileCount = 47;

            Assert.Equal(expectedTbSAFundCount, this.tbSAFundCount);
            Assert.Equal(expectedTbFileCount, this.tbFileCount);
            var agreement = SetAgreementValues();

            using (base.Context)
            {
                await this.service.UploadAgreement(agreement);

                Assert.Equal(expectedTbSAFundCount + 1, base.Context.TbServiceAgreementFund.Count());
                Assert.Equal(expectedTbFileCount + 1, base.Context.TbFile.Count());
            }
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(100)]
        [InlineData(100000)]
        public async Task UploadAgreement_Fund_WithUnvalidId_ShouldThrowException(int fundId)
        {
            var agreement = FileServiceTestData.GenerateAgreement(fundId, "20160101");

            Func<Task> task = async () => await this.service.UploadAgreement(agreement);

            await Assert.ThrowsAsync<CustomSqlException>(task);
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData("Invalid")]
        [InlineData(null)]
        public async Task UploadAgreement_Fund_WithUnvalidAgrType_ShouldThrowException(string agrType)
        {
            var agreement = SetAgreementValues(agrType);

            Func<Task> task = async () => await this.service.UploadAgreement(agreement);

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        [Fact]
        public async Task DeleteDocument_Fund_ShouldDecreaseCount()
        {
            var expectedTbMapCount = 31;
            var expectedTbFileCount = 47;

            var document = this.SetDocumentValues();

            using (base.Context)
            {
                await this.service.UploadDocument(document);

                Assert.Equal(expectedTbMapCount + 1, base.Context.TbMapFilefund.Count());
                Assert.Equal(expectedTbFileCount + 1, base.Context.TbFile.Count());

                await this.service.DeleteDocument(51, "Fund");

                Assert.Equal(expectedTbMapCount, base.Context.TbMapFilefund.Count());
                Assert.Equal(expectedTbFileCount, base.Context.TbFile.Count());
            }
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(100000)]
        public async Task DeleteDocument_Fund_WithInvalidId_ShouldThrowException(int fileId)
        {
            Func<Task> task = async () => await this.service.DeleteDocument(fileId, "Fund");

            await Assert.ThrowsAsync<EntityNotFoundException>(task);
        }

        [Fact]
        public async Task DeleteAgreement_Fund_ShouldDecreaseCount()
        {
            var expectedTbSAFundCount = 13;
            var expectedTbFileCount = 47;

            var agreement = SetAgreementValues();

            using (base.Context)
            {
                await this.service.UploadAgreement(agreement);

                Assert.Equal(expectedTbSAFundCount + 1, base.Context.TbServiceAgreementFund.Count());
                Assert.Equal(expectedTbFileCount + 1, base.Context.TbFile.Count());

                await this.service.DeleteAgreement(51, "Fund");

                Assert.Equal(expectedTbSAFundCount, base.Context.TbServiceAgreementFund.Count());
                Assert.Equal(expectedTbFileCount, base.Context.TbFile.Count());
            }
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(100000)]
        public async Task DeleteAgreement_Fund_WithInvalidId_ShouldThrowException(int fileId)
        {
            Func<Task> task = async () => await this.service.DeleteAgreement(fileId, "Fund");

            await Assert.ThrowsAsync<EntityNotFoundException>(task);
        }

        private UploadAgreementInputModel SetAgreementValues(string agrType = "Management Company Agreement")
        {
            var fundId = 16;
            var tbSaAgr = base.Context.TbServiceAgreementFund.ToList();
            var activationDate = tbSaAgr
                .Where(x => x.SaFundId == fundId)
                .Select(x => x.SaActivationDate)
                .FirstOrDefault();

            return FileServiceTestData.GenerateAgreement(fundId, activationDate.ToString(), agrType);
        }

        private UploadDocumentInputModel SetDocumentValues(string docType = "Prospectus")
        {
            var fundId = 16;
            var tbMapFile = base.Context.TbMapFilefund.ToList();
            var startConnection = tbMapFile
                .Where(x => x.DocFundId == fundId)
                .Select(x => (DateTime)x.DocEndConnection)
                .FirstOrDefault();

            return FileServiceTestData.GenerateDocument(fundId, startConnection.AddDays(1), docType);
        }
    }
}
