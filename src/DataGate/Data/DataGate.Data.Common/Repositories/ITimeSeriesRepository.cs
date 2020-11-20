namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITimeSeriesRepository : IDisposable
    {
        ISet<string> All(string area);

        IReadOnlyCollection<string> AllTbDomTimeSeriesType(int type);

        Task<string> ByName(string area, int? id);
    }
}
