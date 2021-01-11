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

    public class FileServiceTests : SqlServerContextProvider
    {
        private readonly FileService service;
        private readonly int tbMapFileFundCount;
        private readonly int tbSAFundCount;
        private readonly int tbFileCount;

        public FileServiceTests()
        {
            this.service = FileServiceTestData.Service(base.Context, base.Configuration);
            this.tbMapFileFundCount = base.Context.TbMapFilefund.Count();
            this.tbFileCount = base.Context.TbFile.Count();
            this.tbSAFundCount = base.Context.TbServiceAgreementFund.Count();
        }

        [Fact]
        public async Task UploadDocument_Fund_ShouldIncreaseCount()
        {
            var expectedTbMapCount = 1;
            var expectedTbFileCount = 2;

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
            var document = FileServiceTestData.Generate(fundId, startConnection);

            async Task task() => await this.service.UploadDocument(document);

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

            async Task task() => await this.service.UploadDocument(document);

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        [Fact]
        public async Task UploadAgreement_Fund_ShouldIncreaseCount()
        {
            var expectedTbSAFundCount = 1;
            var expectedTbFileCount = 2;

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
            var agreement = FileServiceTestData.Generate(fundId, "20160101");

            async Task task() => await this.service.UploadAgreement(agreement);

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

            async Task task() => await this.service.UploadAgreement(agreement);

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }

        [Fact]
        public async Task DeleteDocument_Fund_ShouldDecreaseCount()
        {
            var expectedTbMapCount = 1;
            var expectedTbFileCount = 2;

            var document = this.SetDocumentValues();

            using (base.Context)
            {
                await this.service.UploadDocument(document);

                Assert.Equal(expectedTbMapCount + 1, base.Context.TbMapFilefund.Count());
                Assert.Equal(expectedTbFileCount + 1, base.Context.TbFile.Count());

                await this.service.DeleteDocument(3, "Fund");

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
            async Task task() => await this.service.DeleteDocument(fileId, "Fund");

            await Assert.ThrowsAsync<EntityNotFoundException>(task);
        }

        [Fact]
        public async Task DeleteAgreement_Fund_ShouldDecreaseCount()
        {
            var expectedTbSAFundCount = 1;
            var expectedTbFileCount = 2;

            var agreement = SetAgreementValues();

            using (base.Context)
            {
                await this.service.UploadAgreement(agreement);

                Assert.Equal(expectedTbSAFundCount + 1, base.Context.TbServiceAgreementFund.Count());
                Assert.Equal(expectedTbFileCount + 1, base.Context.TbFile.Count());

                await this.service.DeleteAgreement(3, "Fund");

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
            async Task task() => await this.service.DeleteAgreement(fileId, "Fund");

            await Assert.ThrowsAsync<EntityNotFoundException>(task);
        }

        private UploadAgreementInputModel SetAgreementValues(string agrType = "Management Company Agreement")
        {
            var fundId = 16;
            var tbSaAgr = base.Context.TbServiceAgreementFund.ToList();
            var activationDate = DateTime.Now.ToString();

            return FileServiceTestData.Generate(fundId, activationDate, agrType);
        }

        private UploadDocumentInputModel SetDocumentValues(string docType = "Prospectus")
        {
            var fundId = 16;
            var tbMapFile = base.Context.TbMapFilefund.ToList();
            var startConnection = DateTime.Now;

            return FileServiceTestData.Generate(fundId, startConnection, docType);
        }

        // TODO existing connection
        //private UploadAgreementInputModel SetAgreementValues(string agrType = "Management Company Agreement")
        //{
        //    var fundId = 16;
        //    var tbSaAgr = base.Context.TbServiceAgreementFund.ToList();
        //    var activationDate = tbSaAgr
        //        .Where(x => x.SaFundId == fundId)
        //        .Select(x => x.SaActivationDate)
        //        .FirstOrDefault();

        //    return FileServiceTestData.Generate(fundId, activationDate.ToString(), agrType);
        //}

        //private UploadDocumentInputModel SetDocumentValues(string docType = "Prospectus")
        //{
        //    var fundId = 16;
        //    var tbMapFile = base.Context.TbMapFilefund.ToList();
        //    var startConnection = tbMapFile
        //        .Where(x => x.DocFundId == fundId)
        //        .Select(x => (DateTime)x.DocEndConnection)
        //        .FirstOrDefault();

        //    return FileServiceTestData.Generate(fundId, startConnection.AddDays(1), docType);
        //}
    }
}
