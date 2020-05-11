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
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.SqlClient.Contracts;

    using Microsoft.Extensions.Configuration;

    // _____________________________________________________________
    public class SqlQueryManager : ISqlQueryManager
    {
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public SqlQueryManager(IConfiguration config)
        {
            this.configuration = config;
        }

        public void ExecuteProcedure(SqlConnection connection, SqlCommand command)
        {
            this.SetParameters(command);

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

        public IEnumerable<string[]> ExecuteQuery(string function, DateTime? date, int? id, IEnumerable<string> columns)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (!date.HasValue)
                {
                    command.CommandText = $"select * from {function}({id})";
                }

                if (id.HasValue)
                {
                    if (columns != null)
                    {
                        command.CommandText = $"select {string.Join(", ", columns)} from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                    }
                    else
                    {
                        command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                    }
                }
                else
                {
                    if (columns != null)
                    {
                        command.CommandText = $"select {string.Join(", ", columns)} from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                    }
                    else
                    {
                        command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                    }
                }

                return DataSQLHelper.GetStringData(command);
            }
        }

        // ________________________________________________________
        //
        // Convert rows values from a data reader into typed results
        // using IDataReaderParser interface
        public IEnumerable<T> ExecuteQueryMapping<T>(string function, int id, DateTime? date)
            where T : IDataReaderParser, new()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (date.HasValue)
                {
                    command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                }
                else
                {
                    command.CommandText = $"select * from {function}({id})";
                }

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

        private SqlCommand SetUpSqlConnectionCommand(SqlConnection connection)
        {
            connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            return command;
        }

        private void SetParameters(SqlCommand command)
        {
            foreach (SqlParameter parameter in command.Parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }
        }

        public async IAsyncEnumerable<string[]> ExecuteQueryAsync(string function, DateTime? date, int? id, IEnumerable<string> columns)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
                await connection.OpenAsync();
                SqlCommand command = connection.CreateCommand();

                if (!date.HasValue)
                {
                    command.CommandText = $"select * from {function}({id})";
                }
                else if (id.HasValue)
                {
                    if (columns != null)
                    {
                        command.CommandText = $"select {string.Join(", ", columns)} from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                    }
                    else
                    {
                        command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}', {id})";
                    }
                }
                else
                {
                    if (columns != null)
                    {
                        command.CommandText = $"select {string.Join(", ", columns)} from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                    }
                    else
                    {
                        command.CommandText = $"select * from {function}('{date?.ToString(GlobalConstants.RequiredSqlDateTimeFormat)}')";
                    }
                }

                await foreach (var item in DataSQLHelper.GetStringDataAsync(command))
                {
                    yield return item;
                }
            }
        }
    }
}
