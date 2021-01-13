// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.TestData
{
    using System;

    using DataGate.Data;
    using DataGate.Data.Models.Entities;
    using DataGate.Data.Repositories.AppContext;
    using DataGate.Services.Data.Storage;
    using DataGate.Services.SqlClient;
    using DataGate.Web.InputModels.ShareClasses;

    using Microsoft.Extensions.Configuration;

    public static class ShareClassStorageTestData
    {
        public static ShareClassStorageService CreateService(ApplicationDbContext context, IConfiguration configuration)
        {
            var sqlManager = new SqlQueryManager(configuration);
            var repositorySC = new EfAppRepository<TbHistoryShareClass>(context);
            var repositorySF = new EfAppRepository<TbHistorySubFund>(context);
            var repositorySelectList = new ShareClassRepository(context);

            var service = new ShareClassStorageService(sqlManager, repositorySC, repositorySelectList, repositorySF);
            return service;
        }

        public static CreateShareClassInputModel Generate()
        {
            CreateShareClassInputModel model = new CreateShareClassInputModel()
            {
                InitialDate = DateTime.Now,
                ShareClassName = "Test Share Class",
                Status = "Active",
                FACode = "test",
                CurrencyCode = "USD",
                SubFundContainer = "1st SICAV - Athena Balanced"
            };

            return model;
        }
    }
}