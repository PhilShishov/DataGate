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

            var fundId = 16;
            var tbMapFile = base.Context.TbMapFilefund.ToList();
            var startConnection = tbMapFile
                .Where(x => x.DocFundId == fundId)
                .Select(x => (DateTime)x.DocEndConnection)
                .FirstOrDefault();

            var document = FileServiceTestData.GenerateDocument(fundId, "Prospectus", startConnection.AddDays(1));

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
            var validDocType = "Prospectus";

            var document = FileServiceTestData.GenerateDocument(fundId, validDocType, startConnection);

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
            var fundId = 16;
            var tbMapFile = base.Context.TbMapFilefund.ToList();
            var startConnection = tbMapFile
                .Where(x => x.DocFundId == fundId)
                .Select(x => x.DocStartConnection.AddDays(1))
                .FirstOrDefault();

            var document = FileServiceTestData.GenerateDocument(fundId, docType, startConnection);

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

            var fundId = 16;
            var tbSaAgr = base.Context.TbServiceAgreementFund.ToList();
            var activationDate = tbSaAgr
                .Where(x => x.SaFundId == fundId)
                .Select(x => x.SaActivationDate)
                .FirstOrDefault();

            var agreement = FileServiceTestData.GenerateAgreement(fundId, "Management Company Agreement", activationDate.ToString());

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
        [InlineData(1)]
        public async Task UploadAgreement_Fund_WithUnvalidId_ShouldThrowException(int fundId)
        {
            var validAgrType = "Management Company Agreement";

            var agreement = FileServiceTestData.GenerateAgreement(fundId, validAgrType, "20160101");

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
            var fundId = 16;
            var tbSaAgr = base.Context.TbServiceAgreementFund.ToList();
            var activationDate = tbSaAgr
                .Where(x => x.SaFundId == fundId)
                .Select(x => x.SaActivationDate)
                .FirstOrDefault();

            var agreement = FileServiceTestData.GenerateAgreement(16, agrType, activationDate.ToString());

            Func<Task> task = async () => await this.service.UploadAgreement(agreement);

            await Assert.ThrowsAsync<ArgumentNullException>(task);
        }


        //[Fact]
        //public async Task DeleteDocument_ShouldDecreaseCount()
        //{
        //    await this.service.UploadDocument(this.testDocument);

        //    Assert.Equal(21, this.tbMapFileFundCount);
        //    Assert.Equal(21, this.tbFileCount);

        //    //this.service.DeleteDocument();
        //}

        //[Fact]
        //public async Task DeleteAgreement_ShouldDecreaseCount()
        //{
        //   await this.service.UploadDocument(this.testDocument);

        //    Assert.Equal(21, this.tbMapFileFundCount);
        //    Assert.Equal(21, this.tbFileCount);

        //    //this.service.DeleteAgreement();
        //}
    }
}
