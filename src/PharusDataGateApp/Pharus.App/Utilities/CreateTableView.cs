// Utility class for creating table view
// based on a search string condition

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Utilities
{
    using System.Collections.Generic;

    // _____________________________________________________________
    public class CreateTableView
    {
        public static void AddTableToView(List<string[]> activeFunds, List<string[]> tableFundsWithoutHeaders, string searchString)
        {
            foreach (var fund in tableFundsWithoutHeaders)
            {
                foreach (var stringValue in fund)
                {
                    // ---------------------------------------------------------
                    //
                    // ToLower method for making
                    // values equivalent to compare
                    if (stringValue != null && stringValue
                        .ToLower()
                        .Contains(searchString.ToLower()))
                    {
                        activeFunds.Add(fund);
                        break;
                    }
                }
            }
        }

        public static void AddHeadersToView(List<string[]> activeFunds, List<string[]> tableHeaders)
        {
            foreach (var tableHeader in tableHeaders)
            {
                activeFunds.Add(tableHeader);
            }
        }
    }
}