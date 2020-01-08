namespace Pharus.Services.Funds
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using Microsoft.Extensions.Configuration;

    using Pharus.Services.Files;

    public class EntitiesFileService : IEntitiesFileService
    {
        // Different filetypes
        private const int fileTypeProspectus = 2;
        private const int fileTypeKiid = 3;
        private const int fileTypePricingPolicy = 4;
        private const int fileTypeNavReport = 5;

        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public EntitiesFileService(IConfiguration config)
        {
            this.configuration = config;
        }

        public string LoadEntityFileToDisplay(
                                           int fundId,
                                           string chosenDate,
                                           int fileTypeId)
        {
            string filePath = string.Empty;
            SqlDataReader dataReader;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select [dbo].[fn_getSpecificFilepath_filefund]" +
                    $"( {fundId},'{chosenDate}',{fileTypeProspectus}) [FILEPATH]";

                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    if (!dataReader.IsDBNull(0))
                    {
                        filePath = (string)dataReader["FILEPATH"];
                    }

                    // Throw exception for null columns

                }
                dataReader.Close();
                return filePath;
            }
        }

        public void AddFileToSpecificEntity(
                                    string file_name,
                                    int fundId,
                                    DateTime startConnection,
                                    DateTime? endConnection,
                                    int fileTypeId)
        {
            string query = "EXEC sp_insert_map_fund " +
                "@file_name, @fund_id, @start_connection, @end_connection, @filetype_id";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar, 100) { Value = file_name },
                        new SqlParameter("@fund_id", SqlDbType.Int) { Value = fundId },
                        new SqlParameter("@start_connection", SqlDbType.NVarChar, 100) { Value = startConnection.ToString("yyyyMMdd") },
                        new SqlParameter("@end_connection", SqlDbType.NVarChar, 100) { Value = endConnection?.ToString("yyyyMMdd") },
                        new SqlParameter("@filetype_id", SqlDbType.Int) { Value = fileTypeId },
                    });

                    foreach (SqlParameter parameter in command.Parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }

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
            }
        }
    }
}