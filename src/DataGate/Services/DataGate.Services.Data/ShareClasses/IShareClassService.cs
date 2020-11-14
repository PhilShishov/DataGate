namespace DataGate.Services.Data.ShareClasses
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Web.ViewModels.Search;

    public interface IShareClassService : IEntityAutocompleteService, IEntityException
    {
        IEnumerable<ResultViewModel> ByName(string searchTerm);

        IEnumerable<TbPrimeShareClass> ByDate();

        bool IsIsin(string searchTerm);

        int ByIsin(string searchTerm);
    }
}
