// Utility class for creating table model

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Utilities.Services
{
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    // _____________________________________________________________
    public class CreateModel
    {
        // ________________________________________________________
        //
        // Create a model by reading table data
        // from SQL Server with headers and values
        public static List<string[]> CreateModelWithHeadersAndValue(SqlCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                var model = ReadTableData
                    .ReadTableValue(reader)
                    .ToList();

                var item = ReadTableData
                    .ReadTableHeader(reader);

                model.Insert(0, item);

                return model;
            }
        }       
    }
}