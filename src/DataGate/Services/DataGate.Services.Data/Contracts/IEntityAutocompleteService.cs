namespace DataGate.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IEntityAutocompleteService
    {
        ISet<string> GetNames(int? id = null);
    }
}
