namespace DataGate.Services.Data.Common
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Queries;

    public interface ISubEntitiesService
    {
        IAsyncEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take = null, int skip = 0);

        IAsyncEnumerable<string[]> GetSubEntitiesSelected(GetWithSelectionDto dto, int? take = null, int skip = 0);
    }
}
