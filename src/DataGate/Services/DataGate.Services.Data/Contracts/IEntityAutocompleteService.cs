namespace DataGate.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntityAutocompleteService
    {
        Task<ISet<string>> GetNames(int? id = null);
    }
}
