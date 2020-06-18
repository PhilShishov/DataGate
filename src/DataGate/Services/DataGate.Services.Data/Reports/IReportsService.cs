namespace DataGate.Services.Data.Reports
{
    using System;
    using System.Collections.Generic;

    public interface IReportsService
    {
        IEnumerable<T> GetAll<T>(string function, DateTime date);
    }
}
