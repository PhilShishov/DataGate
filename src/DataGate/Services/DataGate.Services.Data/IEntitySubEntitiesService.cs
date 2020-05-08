namespace DataGate.Services.Data
{
    using System;
    using System.Collections.Generic;

    public interface IEntitySubEntitiesService
    {
        //IEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take = null, int skip = 0);

        //IEnumerable<string> GetHeaders(int id, DateTime? date);

        ISet<string> GetNames(int? id);

        IEnumerable<string[]> GetSubEntitiesSelected(
                        int id,
                        IReadOnlyCollection<string> preSelectedColumns,
                        IEnumerable<string> selectedColumns,
                        DateTime? date,
                        int? take = null,
                        int skip = 0);
    }
}
