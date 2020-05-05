namespace DataGate.Services.Data
{
    using System;
    using System.Collections.Generic;

    public interface IEntitySubEntitiesService
    {
        IEnumerable<string[]> GetEntityWithDateById(DateTime? date, int id);

        IEnumerable<string[]> GetEntity_SubEntities(DateTime? date, int id);

        IEnumerable<string[]> GetEntity_SubEntitiesWithSelectedViewAndDate(
                        IReadOnlyCollection<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? date,
                        int id);

        IEnumerable<string[]> GetTimeline(int id);

        IEnumerable<string[]> GetDistinctDocuments(DateTime? date, int id);

        IEnumerable<string[]> GetAllDocuments(int id);

        IEnumerable<string[]> GetDistinctAgreements(DateTime? date, int id);

        IEnumerable<string[]> GetAllAgreements(DateTime? date, int id);

        IEnumerable<string[]> PrepareEntity_SubEntitiesForPdfExtract(DateTime? date);

        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
