namespace DataGate.Services.Data
{
    using System;
    using System.Collections.Generic;

    public interface IEntitySubEntitiesService
    {
        IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date);

        IEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take = null, int skip = 0);

        IEnumerable<string> GetHeaders(int id, DateTime? date);

        IEnumerable<string[]> GetSubEntitiesSelected(
                        int id,
                        IReadOnlyCollection<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? date,
                        int? take = null,
                        int skip = 0);

        IEnumerable<T> GetTimeline<T>(int id);

        IEnumerable<T> GetDistinctDocuments<T>(int id, DateTime? date);

        IEnumerable<T> GetAllDocuments<T>(int id);

        IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date);

        IEnumerable<T> GetAllAgreements<T>(int id, DateTime? date);

        IEnumerable<string[]> PrepareEntity_SubEntitiesForPdfExtract(DateTime? date);

        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
