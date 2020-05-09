namespace DataGate.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISubEntitiesService
    {
        IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date);

        IEnumerable<T> GetTimeline<T>(int id);

        IEnumerable<T> GetDistinctDocuments<T>(int id, DateTime? date);

        IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date);

        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
