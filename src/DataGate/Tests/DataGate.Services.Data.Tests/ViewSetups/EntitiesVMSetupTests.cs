// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ViewSetups
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Xunit;

    [Collection(GlobalConstants.SqlServerCollection)]
    public class EntitiesVMSetupTests
    {
        private readonly EntityService service;

        public EntitiesVMSetupTests(SqlServerFixture fixture)
        {
            this.service = EntityServiceTestData.CreateService(fixture.Context, fixture.Configuration);
        }

        [Fact]
        public async Task EntitiesVMSetup_SetGet_ShouldReturnViewModel()
        {
            string[] userColumns = new[] { "ID", "NAME" };

            var viewModel = await EntitiesVMSetup
                .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveShareClass, userColumns);

            Assert.NotNull(viewModel);
            Assert.Equal(6, viewModel.Headers.Count);
            Assert.Equal(2, viewModel.SelectedColumns.Count());

        }

        [Fact]
        public async Task EntitiesVMSetup_SetPost_ShouldUpdateModel()
        {
            EntitiesViewModel model = new EntitiesViewModel();

            await EntitiesVMSetup.SetPost(model, this.service,
                SqlFunctionDictionary.AllShareClass,
                SqlFunctionDictionary.AllActiveShareClass);

            Assert.NotNull(model.Values);
            Assert.True(model.Values.Count > 0);
        }

        [Fact]
        public async Task EntitiesVMSetup_SetGet_InvalidData_ShouldThrowException()
        {
            string[] userColumns = new[] { "NOT A COLUMN" };

            Func<Task> task = async () =>
            {
                var viewModel = await EntitiesVMSetup
                    .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveShareClass,
                        userColumns);

            };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(task);
        }
    }
}
