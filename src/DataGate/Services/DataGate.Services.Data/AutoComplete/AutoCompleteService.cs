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
        public static List<string[]> GetEntityResult(string selectTerm, IEntityService<string[]> service)
        {
            var result = service
                            .GetAll(null)
                            .Skip(1)
                            .ToList();

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
