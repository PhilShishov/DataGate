// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DataGate.Data.Common.Repositories.AppContext;
using DataGate.Data.Models.Entities;
using DataGate.Data.Repositories.AppContext;
using DataGate.Services.Data.Entities;
using DataGate.Services.Data.Funds;

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

    public static class FundServiceTestData
    {
        public static IEnumerable<TbHistoryFund> Generate()
        {
            for (int i = 1; i < 10; i++)
            {
                yield return new TbHistoryFund
                {
                    FId = i,
                    FInitialDate = new DateTime(2020, 01, i),
                };
            }
        }

        public static FundService Service(IEnumerable<TbHistoryFund> testData,
            ApplicationDbContext context)
        {
            context.TbHistoryFund.AddRangeAsync(testData);
            context.SaveChangesAsync();
            IAppRepository<TbHistoryFund> repository = new EfAppRepository<TbHistoryFund>(context);
            var service = new FundService(repository);
            return service;
        }
    }
}