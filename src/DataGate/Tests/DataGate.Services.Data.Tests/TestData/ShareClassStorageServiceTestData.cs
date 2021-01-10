// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DataGate.Services.Data.Storage;
using DataGate.Web.InputModels.ShareClasses;

namespace DataGate.Services.Data.Tests.TestData
{
    using System;
    using System.IO;
    using System.Text;

    using DataGate.Data;
    using DataGate.Data.Models.Domain;
    using DataGate.Data.Models.Entities;
    using DataGate.Data.Repositories.AppContext;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Files;
    using DataGate.Services.SqlClient;
    using DataGate.Web.InputModels.Files;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    public static class ShareClassStorageServiceTestData
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
        public static CreateShareClassInputModel GenerateDocument()
        {
            CreateShareClassInputModel model = new CreateShareClassInputModel()
            {
                EndDate = DateTime.Parse("2019-01-01"),
                ShareClassName = "Test Share Class",
                InitialDate = DateTime.Now,
                Status = "Active",
                FACode = "test",
                CurrencyCode = "USD",
                SubFundContainer = "1st SICAV - Athena Balanced"
            };

            return model;
        }
    }
}