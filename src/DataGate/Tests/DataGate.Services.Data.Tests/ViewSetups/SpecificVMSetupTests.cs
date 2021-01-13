// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ViewSetups
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Xunit;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class SpecificVMSetupTests
    {
        private readonly IEntityDetailsService service;
        private readonly IFundService fundService;
        private readonly IEnumerable<TbHistoryFund> testData;

        public SpecificVMSetupTests(SqlServerFixture fixture)
        {
            this.service = EntityDetailsServiceTestData.CreateService(fixture.Context, fixture.Configuration);
            this.testData = FundServiceTestData.Generate();
            //this.fundService = FundServiceTestData.Service(testData, fixture.Context);
        }

        [Fact]
        public async Task SpecificVM_SetGet_ShouldReturnViewModel()
        {
            int id = 1;
            string date = "2020-01-01";

            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = SqlFunctionDictionary.ByIdFund,
                SqlFunctionActiveSE = SqlFunctionDictionary.FundActiveSubFunds,
                SqlFunctionDistinctDocuments = SqlFunctionDictionary.DistinctDocumentsFund,
                SqlFunctionDistinctAgreements = SqlFunctionDictionary.DistinctAgreementsFund,
            };

            var viewModel = await SpecificVMSetup
                .SetGet<SpecificEntityViewModel>(
                id, 
                date, 
                this.service,  
                dto);

            Assert.NotNull(viewModel);
            Assert.Equal(2, viewModel.Entity.Count());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("         ")]
        public async Task SpecificVM_SetGet_InvalidFunction_ShouldThrowException(string function)
        {
            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = function,
                SqlFunctionActiveSE = SqlFunctionDictionary.FundActiveSubFunds,
                SqlFunctionDistinctDocuments = SqlFunctionDictionary.DistinctDocumentsFund,
                SqlFunctionDistinctAgreements = SqlFunctionDictionary.DistinctAgreementsFund,
            };

            async Task task()
            {
                var viewModel = await SpecificVMSetup
                    .SetGet<SpecificEntityViewModel>(
                    1,
                    "2020-01-01",
                    this.service,
                    dto);

                Assert.NotNull(viewModel);
                Assert.Equal(2, viewModel.Entity.Count());
            }

            await Assert.ThrowsAsync<SqlException>(task);
        }

        [Theory]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("         ")]
        public async Task SpecificVM_SetGet_InvalidDate_ShouldThrowException(string date)
        {
            var dto = new QueriesToPassDto()
            {
                SqlFunctionById = SqlFunctionDictionary.ByIdFund,
                SqlFunctionActiveSE = SqlFunctionDictionary.FundActiveSubFunds,
                SqlFunctionDistinctDocuments = SqlFunctionDictionary.DistinctDocumentsFund,
                SqlFunctionDistinctAgreements = SqlFunctionDictionary.DistinctAgreementsFund,
            };

            async Task task()
            {
                var viewModel = await SpecificVMSetup
                    .SetGet<SpecificEntityViewModel>(
                    1,
                    date,
                    this.service,
                    dto);

                Assert.NotNull(viewModel);
                Assert.Equal(2, viewModel.Entity.Count());
            }

            await Assert.ThrowsAsync<FormatException>(task);
        }
    }
}
