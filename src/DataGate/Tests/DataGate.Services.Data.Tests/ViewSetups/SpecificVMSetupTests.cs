// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Threading.Tasks;
using DataGate.Data.Models.Entities;
using DataGate.Services.Data.Entities;
using DataGate.Services.Data.Funds;
using DataGate.Services.Data.Tests.TestData;
using DataGate.Services.Data.ViewSetups;
using DataGate.Web.Dtos.Queries;
using DataGate.Web.Helpers;
using DataGate.Web.Infrastructure.Extensions;
using DataGate.Web.ViewModels.Entities;
using Xunit;

namespace DataGate.Services.Data.Tests.ViewSetups
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpecificVMSetupTests : SqlServerContextProvider
    {
        private readonly IEntityDetailsService service;
        private readonly IFundService fundService;
        private readonly IEnumerable<TbHistoryFund> testData;

        public SpecificVMSetupTests()
        {
            this.service = EntityDetailsServiceTestData.CreateService(base.Context, base.Configuration);
            this.testData = FundServiceTestData.Generate();
            this.fundService = FundServiceTestData.Service(testData, base.Context);
        }

        [Fact]
        public async Task EntitiesVMSetup_SetGet_ShouldReturnViewModel()
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

            await using (base.Context)
            {
                var viewModel = await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, this.fundService, dto);

                Assert.NotNull(viewModel);
                Assert.True(viewModel.Entity.Count() == 2);
            }
        }

        [Fact]
        public async Task EntitiesVMSetup_SetGet_InvalidData_ShouldThrowException()
        {
            int id = -1;
            string date = "2020-01-01";

            var dto = new QueriesToPassDto();

            Func<Task> task = async () =>
            {
                await using (base.Context)
                {
                    var viewModel =
                        await SpecificVMSetup.SetGet<SpecificEntityViewModel>(id, date, this.service, this.fundService,
                            dto);

                    Assert.NotNull(viewModel);
                    Assert.True(viewModel.Entity.Count() == 2);
                }
            };

            await Assert.ThrowsAsync<DataGate.Common.Exceptions.EntityNotFoundException>(task);
        }
    }
}
