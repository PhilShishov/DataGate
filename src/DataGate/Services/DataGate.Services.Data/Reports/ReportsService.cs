// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class ReportsService : IReportsService
    {
        private readonly ISqlQueryManager sqlManager;

        public ReportsService(ISqlQueryManager sqlQueryManager)
        {
            this.sqlManager = sqlQueryManager;
        }

        public IEnumerable<T> All<T>(string function, DateTime date)
        {
            IEnumerable<ReportDto> dto = this.sqlManager.ExecuteQueryMapping<ReportDto>(function, null, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IAsyncEnumerable<string[]> All(string function, DateTime date, int skip)
        => this.sqlManager.ExecuteQueryReportsAsync(function, date).Skip(skip);
    }
}
