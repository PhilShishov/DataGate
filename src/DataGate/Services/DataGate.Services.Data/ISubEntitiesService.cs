namespace DataGate.Services.Data
{
    using System;
    using System.Collections.Generic;

    public interface ISubEntitiesService
    {
        IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date);

        IEnumerable<T> GetTimeline<T>(int id);

        IEnumerable<T> GetDistinctDocuments<T>(int id, DateTime? date);

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);

        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);

        IEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take = null, int skip = 0);

        IEnumerable<string> GetHeaders(int id, DateTime? date);
    }
}
