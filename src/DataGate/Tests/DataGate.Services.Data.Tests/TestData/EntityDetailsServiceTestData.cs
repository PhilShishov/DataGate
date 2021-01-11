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

    public static class EntityDetailsServiceTestData
    {

        public static EntityDetailsService CreateService(ApplicationDbContext context, IConfiguration configuration)
        {
            var sqlManager = new SqlQueryManager(configuration);

            var service = new EntityDetailsService(sqlManager);
            return service;
        }
    }
}