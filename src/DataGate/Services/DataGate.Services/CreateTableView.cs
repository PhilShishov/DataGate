// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for creating table view
// based on a search string condition

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services
{
    using System.Collections.Generic;

    // _____________________________________________________________
    public class CreateTableView
    {
        private const int IndexEntityNameInTable = 3;

        public static List<string[]> AddTableToView(IEnumerable<string[]> entities, string searchString)
        {
            var tableValues = new List<string[]>();

            foreach (var entity in entities)
            {
                // ---------------------------------------------------------
                //
                // ToLower method for making
                // values equivalent to compare
                if (entity[IndexEntityNameInTable] != null && entity[IndexEntityNameInTable]
                    .ToLower()
                    .Contains(searchString.ToLower()))
                {
                    tableValues.Add(entity);
                    break;
                }
            }

            return tableValues;
        }
    }
}
