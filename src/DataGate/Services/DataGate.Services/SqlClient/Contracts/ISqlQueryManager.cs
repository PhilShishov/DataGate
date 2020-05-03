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

        IEnumerable<string[]> ExecuteQueryByWhereId(DateTime? chosenDate, int id, string function, string column);

        IEnumerable<string[]> ExecuteQueryByDateAndId(DateTime? chosenDate, int id, string function);

        IEnumerable<string[]> ExecuteQueryByIdWithSelection(
                                                    IEnumerable<string> columns,
                                                    DateTime? chosenDate,
                                                    int id,
                                                    string function);
    }
}
