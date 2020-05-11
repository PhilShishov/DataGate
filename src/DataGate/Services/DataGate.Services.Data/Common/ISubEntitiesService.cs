namespace DataGate.Services.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataGate.Web.ViewModels.Queries;

    public interface ISubEntitiesService
    {
        IAsyncEnumerable<string[]> GetSubEntities(int id, DateTime? date);

        IEnumerable<string[]> GetSubEntitiesSelected(GetWithSelectionDto dto, int? take = null,int skip = 0);
    }
}
