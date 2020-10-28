namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITimeSeriesRepository : IDisposable
    {
        ISet<string> GetAll(string area);

        IReadOnlyCollection<string> GetAllTbDomTimeSeriesType(int type);

        Task<string> ByName(string area, int? id);
    }
}
