namespace DataGate.Services.Data.Reports
{
    using System;
    using System.Collections.Generic;

    public interface IReportsService
    {
        IEnumerable<T> All<T>(string function, DateTime date);

        IAsyncEnumerable<string[]> All(string function, DateTime date, int skip = 0);
    }
}
