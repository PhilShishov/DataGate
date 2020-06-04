namespace DataGate.Services.Data.ShareClasses
{
    using System.Collections.Generic;

    using DataGate.Services.Data.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Web.ViewModels.Search;

    public interface IShareClassService : IEntityAutocompleteService, IEntityException
    {
        IEnumerable<ResultViewModel> SearchClassesByName(string searchTerm);

        bool IsIsin(string searchTerm);

        int GetClassByIsin(string searchTerm);
    }
}
