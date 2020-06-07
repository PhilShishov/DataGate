﻿namespace DataGate.Services.Data.TimeSeries
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;

    public class TimeSeriesService : ITimeSeriesService
    {
        private readonly ISqlQueryManager sqlManager;

        public TimeSeriesService(ISqlQueryManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        public async IAsyncEnumerable<string[]> GetData(int id, int skip)
        {
            var query = this.sqlManager
               .ExecuteQueryTimeSeriesAsync(TimeSeriesFunctions.SqlFunctionTimeSeriesData)
               .Skip(skip);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetDates(int id, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryTimeSeriesAsync(TimeSeriesFunctions.SqlFunctionTimeSeriesData)
                .Skip(skip)
                .Select(ts => ts[1]);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetProviders(int id, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryTimeSeriesAsync(TimeSeriesFunctions.SqlFunctionTimeSeriesData)
                .Skip(skip)
                .Select(tt => tt[0]);

            await foreach (var item in query)
            {
                yield return item;
            }
        }
    }
}
