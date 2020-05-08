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

    using DataGate.Services.Data;

    public static class AutoCompleteService
    {
        public static ISet<string> GetResult(string selectTerm, IEntityService service)
        {
            var result = service.GetNames();

            if (selectTerm != null)
            {
                result = result.Where(f => f.ToLower().Contains(selectTerm.ToLower())).ToHashSet();
            }

            return result;
        }

        public static ISet<string> GetResult(string selectTerm, IEntitySubEntitiesService service, int? id)
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
