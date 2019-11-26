namespace Pharus.Services.Utilities
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public class ReadTableData
    {
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
