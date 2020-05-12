// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for creating table view
// based on a search string condition

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

        public static async IAsyncEnumerable<string[]> AddTableToViewAsync(IEnumerable<string[]> entities, string searchString)
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
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    tableValues.Add(entity);
                    break;
                }
            }

            foreach (var item in tableValues)
            {
                yield return item;
            }
        }
    }
}
