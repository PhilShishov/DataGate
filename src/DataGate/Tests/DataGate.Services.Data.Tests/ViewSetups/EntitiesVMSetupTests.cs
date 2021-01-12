// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ViewSetups
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Services.Data.ViewSetups;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Entities;

    using Xunit;

    public class EntitiesVMSetupTests : SqlServerContextProvider
    {
        private readonly EntityService service;

        public EntitiesVMSetupTests()
        {
            this.service = EntityServiceTestData.CreateService(base.Context, base.Configuration);
        }

        [Fact]
        public async Task EntitiesVMSetup_SetGet_ShouldReturnViewModel()
        {
            string[] userColumns = new[] { "ID", "NAME" };

            await using (base.Context)
            {
                var viewModel = await EntitiesVMSetup
                    .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveShareClass, userColumns);

                Assert.NotNull(viewModel);
                Assert.True(viewModel.Headers.Count == 6);
                Assert.True(viewModel.SelectedColumns.Count() == 2);
            }
        }

        [Fact]
        public async Task EntitiesVMSetup_SetPost_ShouldUpdateModel()
        {
            EntitiesViewModel model = new EntitiesViewModel();

            await using (base.Context)
            {
                await EntitiesVMSetup.SetPost(model, this.service, 
                    SqlFunctionDictionary.AllShareClass,
                    SqlFunctionDictionary.AllActiveShareClass);

                Assert.NotNull(model.Values);
                Assert.True(model.Values.Count > 0);
            }
        }

        [Fact]
        public async Task EntitiesVMSetup_SetGet_InvalidData_ShouldThrowException()
        {
            string[] userColumns = new[] { "NOT A COLUMN" };

            Func<Task> task = async () =>
            {
                await using (base.Context)
                {
                    var viewModel = await EntitiesVMSetup
                        .SetGet<EntitiesViewModel>(this.service, SqlFunctionDictionary.AllActiveShareClass,
                            userColumns);
                }
            };

            await Assert.ThrowsAsync<System.Data.SqlClient.SqlException>(task);
        }
    }
}
