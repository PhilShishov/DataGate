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

        public async IAsyncEnumerable<string[]> GetPrices(string function, int id, int skip)
        {
            var query = this.sqlManager
               .ExecuteQueryTimeSeriesAsync(string.Format(function, id))
               .Skip(skip);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetDates(string function, int id, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryTimeSeriesAsync(string.Format(function, id))
                .Skip(skip)
                .Select(ts => ts[1]);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string> GetProviders(string function, int id, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryTimeSeriesAsync(string.Format(function, id))
                .Skip(skip)
                .Select(tt => tt[0]);

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
