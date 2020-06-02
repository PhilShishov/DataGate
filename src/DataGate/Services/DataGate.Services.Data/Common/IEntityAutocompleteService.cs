namespace DataGate.Services.Data.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntityAutocompleteService
    {
        Task<ISet<string>> GetNamesAsync(int? id = null);
    }
}
