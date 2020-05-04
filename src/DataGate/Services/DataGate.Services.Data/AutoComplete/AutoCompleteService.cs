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

    using DataGate.Common;
    using DataGate.Services.Data;

    public static class AutoCompleteService
    {
        public static IEnumerable<string[]> GetResult(string selectTerm, IEntityService service)
        {
            var result = service.GetAll(null, null, 1);

            if (selectTerm != null)
            {
                result = result
                        .Where(f => f[GlobalConstants.IndexEntityNameInSQLTable]
                            .ToLower()
                            .Contains(selectTerm.ToLower()))
                        .ToList();
            }

            return result;
        }
    }
}
