// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing
// the autocomplete function

// Created: 05/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.AutoComplete
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.Data.Contracts;

    public static class AutoCompleteService
    {
        public static ISet<string> GetResult(string selectTerm, IEntityAutocompleteService service, int? id = null)
        {
            var result = service.GetNames(id);

            if (selectTerm != null)
            {
                result = result.Where(f => f.ToLower().Contains(selectTerm.ToLower())).ToHashSet();
            }

            return result;
        }
    }
}
