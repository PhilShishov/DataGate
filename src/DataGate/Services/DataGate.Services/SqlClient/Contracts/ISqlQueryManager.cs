namespace DataGate.Services.SqlClient.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public interface ISqlQueryManager
    {
        void ExecuteScalarSqlConnectionCommand(SqlConnection connection, SqlCommand command);

        IEnumerable<string[]> ExecuteSqlQuery(DateTime? chosenDate, string function);

        IEnumerable<string[]> ExecuteSqlQueryWithSelection(
                                                                    ref List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate,
                                                                    string function);

        IEnumerable<string[]> ExecuteSqlQueryById(int id, string function);

        IEnumerable<string[]> ExecuteSqlQueryByWhereId(DateTime? chosenDate, int id, string function, string column);

        IEnumerable<string[]> ExecuteSqlQueryByDateAndId(DateTime? chosenDate, int id, string function);

        IEnumerable<string[]> ExecuteSqlQueryByIdWithSelection(
                                                                ref List<string> preSelectedColumns,
                                                                List<string> selectedColumns,
                                                                DateTime? chosenDate,
                                                                int id,
                                                                string function);
    }
}
