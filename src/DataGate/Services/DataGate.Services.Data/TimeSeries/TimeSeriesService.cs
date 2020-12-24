// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.TimeSeries
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.SqlClient.Contracts;

    public class TimeSeriesService : ITimeSeriesService
    {
        private readonly ISqlQueryManager sqlManager;

        public TimeSeriesService(ISqlQueryManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        public async IAsyncEnumerable<string[]> GetPrices(string function, int skip)
        {
            var query = this.sqlManager
               .ExecuteQueryTimeSeriesAsync(function)
               .Skip(skip)
               .TakeLast(20);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetDates(string function, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryTimeSeriesAsync(function)
                .Skip(skip)
                .Select(ts => ts[0])
                .TakeLast(20);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetProviders(string function, int skip, bool isMainProvider)
        {
            var query = this.sqlManager
                .ExecuteQueryTimeSeriesAsync(function)
                .Skip(skip)
                .Select(tt => tt[0]);

            if (isMainProvider)
            {
                query = query.Where(pr => pr.Contains("AuM") || pr.Contains("Price"));
            }

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        //public async IAsyncEnumerable<TimeSerieReport> GetAllTSReports(string type, int? id, string timeSeriesType)
        //{

        //}
    }
}
