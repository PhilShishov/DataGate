namespace DataGate.Services.SqlClient
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public interface ICreateModel
    {
        List<string[]> Model { get; set; }

        List<string[]> CreateModelWithHeadersAndValue(SqlCommand command);
    }
}
