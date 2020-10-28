namespace DataGate.Services.Data.TimeSeries
{
    using System.Collections.Generic;

    public interface ITimeSeriesService
    {
        IAsyncEnumerable<string> GetDates(string function, int id, int skip = 0);

        IAsyncEnumerable<string> GetProviders(string function, int id, int skip = 0);

        IAsyncEnumerable<string[]> GetPrices(string function, int id, int skip = 0);

        //IAsyncEnumerable<TimeSerieReport> GetAllTSReports(string type, int? id, string timeSeriesType)
    }
}
