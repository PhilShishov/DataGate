// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DataGate.Services.Data.Entities;

namespace DataGate.Services.Data.Tests.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data;
    using DataGate.Services.SqlClient;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Queries;

    using Microsoft.Extensions.Configuration;

    public static class EntityServiceTestData
    {

        public static async Task<AllSelectedDto> Generate(EntityService service, string function)
        {
            var headers = await service.All(function, null, DateTime.Now, 0).FirstOrDefaultAsync();

            var dto = new AllSelectedDto
            {
                Date = DateTime.Now,
                PreSelectedColumns = headers?.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                SelectedColumns = new List<string>() { "STATUS" },
            };

            return dto;
        }

        public static EntityService CreateService(ApplicationDbContext context, IConfiguration configuration)
        {
            var sqlManager = new SqlQueryManager(configuration);

            var service = new EntityService(sqlManager, configuration, null);
            return service;
        }
    }
}