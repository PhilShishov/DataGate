namespace DataGate.Services.SqlClient.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public interface ISqlQueryManager
    {
        void ExecuteProcedure(SqlCommand command);

        IEnumerable<string[]> ExecuteQuery(string function, DateTime? date = null, int? id = null, IEnumerable<string> columns = null);

        IAsyncEnumerable<string[]> ExecuteQueryAsync(string function, DateTime? date = null, int? id = null, IEnumerable<string> columns = null);

        IEnumerable<T> ExecuteQueryMapping<T>(string function, int id, DateTime? date = null)
            where T : IDataReaderParser, new();
    }
}
