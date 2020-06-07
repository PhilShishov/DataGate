namespace DataGate.Services.Data.TimeSeries
{
    using System.Collections.Generic;

    public interface ITimeSeriesService
    {
        IAsyncEnumerable<string> GetDates(int id, int skip = 0);

        IAsyncEnumerable<string> GetProviders(int id, int skip = 0);

        IAsyncEnumerable<string[]> GetData(int id, int skip = 0);
    }
}
