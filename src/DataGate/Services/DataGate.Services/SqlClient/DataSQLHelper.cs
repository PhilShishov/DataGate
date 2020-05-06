// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for creating table model

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.SqlClient
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using DataGate.Common;

    // _____________________________________________________________
    public static class DataSQLHelper
    {
        private const int StartingIndex = 0;

        // ________________________________________________________
        //
        // Create a model by reading table data
        // from SQL Server with headers and values
        public static IEnumerable<string[]> GetStringData(SqlCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                var model = new List<string[]>();

                // Performance overhead :
                // array of strings and for loop is with fastest access time

                // ________________________________________________________
                //
                // Iterate through each value of the
                // header row and return their values
                var headers = new string[reader.FieldCount];
                for (int i = 0; i < headers.Length; i++)
                {
                    headers[i] = reader.GetName(i);
                }

                var values = GetValues(reader);

                model.Add(headers);
                model.AddRange(values);

                Validator.NotFoundExceptionIfEntityIsNull(model, nameof(model));

                return model;
            }
        }

        // ________________________________________________________
        //
        // Convert rows values from a data reader into typed results
        public static IEnumerable<T> GetData<T>(IDataReader reader, Func<IDataRecord, T> BuildObject)
        {
            while (reader.Read())
            {
                yield return BuildObject(reader);
            }
        }

        // ________________________________________________________
        //
        // Iterate through each value row
        // of the query reader without headers
        // and return their values
        private static IEnumerable<string[]> GetValues(SqlDataReader reader)
        {
            while (reader.Read())
            {
                var values = new string[reader.FieldCount];

                for (int i = StartingIndex; i < values.Length; i++)
                {
                    values[i] = Convert.ToString(reader.GetValue(i));
                }

                yield return values;
            }
        }
    }
}
