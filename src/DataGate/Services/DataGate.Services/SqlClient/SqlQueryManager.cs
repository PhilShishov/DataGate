// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
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

        public IEnumerable<string[]> ExecuteQuery(DateTime? date, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (date == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}')";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                }

                return DataSQLHelper.GetStringData(command);
            }
        }

        public IEnumerable<string[]> ExecuteQueryWithSelection(
                                                            IEnumerable<string> selectedColumns,
                                                            DateTime? date,
                                                            string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (date == null)
                {
                    command.CommandText = $"select {string.Join(", ", selectedColumns)} from {function}('{this.defaultDateTimeWithSqlConversion}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", selectedColumns)} from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                }

                return DataSQLHelper.GetStringData(command);
            }
        }

        public IEnumerable<string[]> ExecuteQueryByDateAndId(int id, DateTime? date, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);
                this.ExecuteQueryByDateAndIdTemplate(id, date, function, command);

                return DataSQLHelper.GetStringData(command);
            }
        }

        public IEnumerable<string[]> ExecuteQueryById(int id, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                command.CommandText = $"select * from {function}({id})";

                return DataSQLHelper.GetStringData(command);
            }
        }

        public IEnumerable<string[]> ExecuteQueryByWhereId(int id, DateTime? date, string function, string column)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (date == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}') where [{column}] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}') " +
                        $"where [{column}] = {id}";
                }

                return DataSQLHelper.GetStringData(command);
            }
        }

        public IEnumerable<string[]> ExecuteQueryByIdWithSelection(
                                                                int id,
                                                                IEnumerable<string> columns,
                                                                DateTime? date,
                                                                string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (date == null)
                {
                    command.CommandText = $"select {string.Join(", ", columns)} from {function}('{this.defaultDateTimeWithSqlConversion}', {id}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", columns)} from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                }

                return DataSQLHelper.GetStringData(command);
            }
        }

        // ________________________________________________________
        //
        // Convert rows values from a data reader into typed results
        // using IDataReaderParser interface
        public IEnumerable<T> ExecuteQueryMapping<T>(int id, DateTime? date, string function)
            where T : IDataReaderParser, new()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                this.ExecuteQueryByDateAndIdTemplate(id, date, function, command);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new T();
                        entity.Parse(reader);
                        yield return entity;
                    }
                }
            }
        }

        private void ExecuteQueryByDateAndIdTemplate(int id, DateTime? date, string function, SqlCommand command)
        {
            if (date == null)
            {
                command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}', {id})";
            }
            else
            {
                command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
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
