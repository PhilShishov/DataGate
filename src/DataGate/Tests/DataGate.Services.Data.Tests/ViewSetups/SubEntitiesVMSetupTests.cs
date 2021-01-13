// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ViewSetups
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Xunit;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class SubEntitiesVMSetupTests
    {
        private readonly EntityService service;
        private readonly IFundService fundService;
        private readonly IEnumerable<TbHistoryFund> testData;

        public SubEntitiesVMSetupTests(SqlServerFixture fixture)
        {
            this.service = EntityServiceTestData.CreateService(fixture.Context, fixture.Configuration);
            this.testData = FundServiceTestData.Generate();
            this.fundService = FundServiceTestData.Service(testData, fixture.Context);
        }

        [Fact]
        public async Task SubEntitiesVM_SetGet_ShouldReturnViewModel()
        {
            var dto = new SubEntitiesGetDto()
            {
                Id = 1,
                Date = "2020-01-01",
                Container = string.Empty,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetGet<SubEntitiesViewModel>(
                this.service, 
                this.fundService, 
                dto, 
                SqlFunctionDictionary.FundSubFunds);

            Assert.NotNull(viewModel);
            Assert.Equal(31, viewModel.Values.Count);
        }

        [Fact]
        public async Task SubEntitiesVM_SetGet_InvalidData_ShouldThrowException()
        {
            async Task task()
            {
                var viewModel = await SubEntitiesVMSetup
                    .SetGet<SubEntitiesViewModel>(
                    this.service,
                    this.fundService,
                    null,
                    SqlFunctionDictionary.FundSubFunds);
            }

            await Assert.ThrowsAsync<NullReferenceException>(task);
        }

        [Fact]
        public async Task SubEntitiesVM_SetLoadedGet_ShouldReturnViewModel()
        {
            var dto = new EntitySubEntitiesGetDto()
            {
                Id = 1,
                Date = "2020-01-01",
                Container = string.Empty,
            };

            var viewModel = await SubEntitiesVMSetup
                .SetLoadedGet<EntitySubEntitiesViewModel>(
                this.service, 
                this.fundService, 
                dto, 
                SqlFunctionDictionary.FundSubFunds);

            Assert.NotNull(viewModel);
            Assert.Equal(32, viewModel.Entities.Count);
        }

        [Fact]
        public async Task SubEntitiesVM_SetLoadedGet_InvalidData_ShouldThrowException()
        {
            var dto = new EntitySubEntitiesGetDto();

            async Task task()
            {
                var viewModel = await SubEntitiesVMSetup
                    .SetLoadedGet<EntitySubEntitiesViewModel>(
                    this.service,
                    this.fundService,
                    dto,
                    SqlFunctionDictionary.FundSubFunds);
            }

            await Assert.ThrowsAsync<SqlException>(task);
        }

        [Fact]
        public async Task SubEntitiesVM_SetPost_ShouldUpdateModel()
        {
            SubEntitiesViewModel viewModel = new SubEntitiesViewModel
            {
                Id = 1
            };

            await SubEntitiesVMSetup.SetPost(
                viewModel, 
                this.service, 
                SqlFunctionDictionary.FundSubFunds);

            Assert.NotNull(viewModel.Values);
            Assert.True(viewModel.Values.Count > 0);
        }

        [Fact]
        public async Task SubEntitiesVM_SetPost_InvalidData_ShouldThrowException()
        {
            SubEntitiesViewModel viewModel = new SubEntitiesViewModel();

            async Task task()
            {
                await SubEntitiesVMSetup.SetPost(
                    viewModel,
                    this.service,
                    SqlFunctionDictionary.FundSubFunds);
            }

            await Assert.ThrowsAsync<SqlException>(task);
        }
    }
}
