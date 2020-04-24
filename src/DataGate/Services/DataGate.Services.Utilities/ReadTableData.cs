// Utility class for reading DB table data

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Utilities.Services
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    // _____________________________________________________________
    public class ReadTableData
    {
        // ________________________________________________________
        //
        // Iterate through each value row
        // of the query reader without headers
        // and return their values
        public static IEnumerable<string[]> ReadTableValue(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<string>();

                for (int j = 0; j < reader.FieldCount; j++)
                {
                    values.Add(Convert.ToString(reader.GetValue(j)));
                }

                yield return values.ToArray();
            }
        }       

        // ________________________________________________________
        //
        // Iterate through each value of the
        // header row and return their values
        public static string[] ReadTableHeader(SqlDataReader reader)
        {
            string[] item = new string[reader.FieldCount];

            for (int j = 0; j < reader.FieldCount; j++)
            {
                item[j] = reader.GetName(j);
            }

            return item;
        }
    }
}