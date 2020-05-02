namespace DataGate.Services.Data
{
    using System;
    using System.Collections.Generic;

    public interface IEntitySubEntitiesService<T>
    {
        IEnumerable<T> GetEntityWithDateById(DateTime? chosenDate, int id);

        IEnumerable<T> GetEntity_SubEntities(DateTime? chosenDate, int id);

        IEnumerable<T> GetEntity_SubEntitiesWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        List<string> selectedColumns,
                        DateTime? chosenDate,
                        int id);

        IEnumerable<T> GetTimeline(int id);

        IEnumerable<T> GetDistinctDocuments(DateTime? chosenDate, int id);

        IEnumerable<T> GetAllDocuments(int id);

        IEnumerable<T> GetDistinctAgreements(DateTime? chosenDate, int id);

        IEnumerable<T> GetAllAgreements(DateTime? chosenDate, int id);

        IEnumerable<T> PrepareEntity_SubEntitiesForPdfExtract(DateTime? chosenDate);

        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
