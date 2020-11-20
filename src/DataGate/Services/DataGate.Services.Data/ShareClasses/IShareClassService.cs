namespace DataGate.Services.Data.ShareClasses
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Common;
    using DataGate.Web.ViewModels.Search;

    public interface IShareClassService : IEntityException
    {
        IEnumerable<SearchViewModel> ByName(string searchTerm);

        IEnumerable<TbPrimeShareClass> ByDate();

        bool IsIsin(string searchTerm);

        int ByIsin(string searchTerm);
    }
}
