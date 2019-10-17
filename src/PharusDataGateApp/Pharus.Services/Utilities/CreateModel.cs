namespace Pharus.Services.Utilities
{
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    public class CreateModel
    {
        public static List<string[]> CreateModelWithHeadersAndValue(SqlCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                var model = ReadTableData.ReadTableValue(reader).ToList();

                var item = ReadTableData.ReadTableHeader(reader);

                model.Insert(0, item);

                return model;
            }
        }
    }
}
