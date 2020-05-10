namespace DataGate.Services.Data.Common
{
    using System;
    using System.Collections.Generic;

    public interface IEntityDetailsService
    {
        IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date);

        IEnumerable<T> GetDistinctDocuments<T>(int id, DateTime? date);

        IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date);
    }
}
