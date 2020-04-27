// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for creating table view
// based on a search string condition

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.Utilities
{
    using System.Linq;
    using System.Collections.Generic;

    // _____________________________________________________________
    public class CreateTableView
    {
        public static IEnumerable<string[]> AddTableToView(List<string[]> entities, string searchString)
        {
            var tableHeaders = entities.Take(1).ToList();
            var tableValues = entities.Skip(1).ToList();

            entities = new List<string[]>();

            AddHeadersToView(entities, tableHeaders);

            foreach (var entity in tableValues)
            {
                foreach (var stringValue in entity)
                {
                    // ---------------------------------------------------------
                    //
                    // ToLower method for making
                    // values equivalent to compare
                    if (stringValue != null && stringValue
                        .ToLower()
                        .Contains(searchString.ToLower()))
                    {
                        entities.Add(entity);
                        break;
                    }
                }
            }

            return entities;
        }

        private static void AddHeadersToView(List<string[]> entities, List<string[]> tableHeaders)
        {
            foreach (var tableHeader in tableHeaders)
            {
                entities.Add(tableHeader);
            }
        }
    }
}