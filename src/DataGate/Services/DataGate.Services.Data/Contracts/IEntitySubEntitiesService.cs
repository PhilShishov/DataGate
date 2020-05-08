namespace DataGate.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Queries;

    public interface IEntitySubEntitiesService
    {
        IEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take = null, int skip = 0);

        IEnumerable<string> GetHeaders(int id, DateTime? date);

        IEnumerable<string[]> GetSubEntitiesSelected(GetWithSelectionDto dto, int? take = null,int skip = 0);
    }
}
