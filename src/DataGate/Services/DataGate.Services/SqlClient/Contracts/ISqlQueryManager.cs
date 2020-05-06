namespace DataGate.Services.SqlClient.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public interface ISqlQueryManager
    {
        void ExecuteScalarSqlConnectionCommand(SqlConnection connection, SqlCommand command);

        IEnumerable<string[]> ExecuteQuery(DateTime? chosenDate, string function);

        IEnumerable<string[]> ExecuteQueryWithSelection(
                                                    IEnumerable<string> columns,
                                                    DateTime? chosenDate,
                                                    string function);

        IEnumerable<string[]> ExecuteQueryById(int id, string function);

        IEnumerable<string[]> ExecuteQueryByWhereId(int id, DateTime? chosenDate, string function, string column);

        IEnumerable<string[]> ExecuteQueryByDateAndId(int id, DateTime? chosenDate, string function);

        IEnumerable<string[]> ExecuteQueryByIdWithSelection(
                                                    int id,
                                                    IEnumerable<string> columns,
                                                    DateTime? chosenDate,
                                                    string function);
    }
}
