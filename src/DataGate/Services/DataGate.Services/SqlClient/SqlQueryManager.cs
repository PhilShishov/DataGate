// Utility class for managing sql
// queries, connections, commands

// Created: 04/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.SqlClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.SqlClient.Contracts;

    using Microsoft.Extensions.Configuration;

    // _____________________________________________________________
    public class SqlQueryManager : ISqlQueryManager
    {
        private readonly string defaultDateTimeWithSqlConversion = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public SqlQueryManager(IConfiguration config)
        {
            this.configuration = config;
        }

        public void ExecuteScalarSqlConnectionCommand(SqlConnection connection, SqlCommand command)
        {
            this.SetUpSqlParametersForDB(command);

            command.Connection = connection;

            try
            {
                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (SqlException sx)
            {
                Console.WriteLine(sx.Message);
            }
        }

        public IEnumerable<string[]> ExecuteSqlQuery(DateTime? chosenDate, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}')";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{chosenDate?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> ExecuteSqlQueryWithSelection(
                                                                    ref List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate,
                                                                    string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                // Prepare items for DB query with []
                preSelectedColumns.AddRange(selectedColumns);
                preSelectedColumns = preSelectedColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col)).ToList();

                if (chosenDate == null)
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {function}('{this.defaultDateTimeWithSqlConversion}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {function}('{chosenDate?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> ExecuteSqlQueryByDateAndId(DateTime? chosenDate, int id, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}', {id})";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{chosenDate?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> ExecuteSqlQueryById(int id, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                command.CommandText = $"select * from {function}({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> ExecuteSqlQueryByWhereId(DateTime? chosenDate, int id, string function, string column)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}') where [{column}] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{chosenDate?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}') " +
                        $"where [{column}] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> ExecuteSqlQueryByIdWithSelection(
                                                                ref List<string> preSelectedColumns,
                                                                List<string> selectedColumns,
                                                                DateTime? chosenDate,
                                                                int id,
                                                                string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                // Prepare items for DB query with []
                preSelectedColumns.AddRange(selectedColumns);
                preSelectedColumns = preSelectedColumns.Select(c => string.Format(GlobalConstants.SqlItemFormatRequired, c)).ToList();

                if (chosenDate == null)
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {function}('{this.defaultDateTimeWithSqlConversion}', {id}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {function}('{chosenDate?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        private SqlCommand SetUpSqlConnectionCommand(SqlConnection connection)
        {
            connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            return command;
        }

        private void SetUpSqlParametersForDB(SqlCommand command)
        {
            foreach (SqlParameter parameter in command.Parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }
        }
    }
}
