// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Utility class for creating table model

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.SqlClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    using DataGate.Common;

    // _____________________________________________________________
    public class SqlHelper
    {
        private const int StartingIndex = 0;

        public static async IAsyncEnumerable<string[]> ExecuteCommand(SqlCommand command)
        {
            Validator.ArgumentNullException(command, ErrorMessages.EmptyCommand);
            Validator.ArgumentNullExceptionString(command.CommandText, ErrorMessages.EmptyCommand);

            using (var reader = await command.ExecuteReaderAsync())
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

                Validator.EntityNotFoundException(model);

                foreach (var item in model)
                {
                    yield return item;
                }
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

                yield return values.ToArray();
            }
        }
    }
}
