namespace Pharus.Services.Funds
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using Microsoft.Extensions.Configuration;

    using Pharus.Services.Files;

    public class EntitiesFileService : IEntitiesFileService
    {
        private const int fileTypeProspectus = 2;
        private const int fileTypeKiid = 3;
        //private const int fileTypePricingPolicy = 4;
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
                                           int entityId,
                                           string chosenDate,
                                           string controllerName)
        {
            string filePath = string.Empty;
            SqlDataReader dataReader;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                if (controllerName == "Funds")
                {
                    command.CommandText = $"select [dbo].[fn_getSpecificFilepath_filefund]" +
                   $"( {entityId},'{chosenDate}',{fileTypeProspectus}) [FILEPATH]";
                }
                else if (controllerName == "SubFunds")
                {
                    command.CommandText = $"select [dbo].[fn_getSpecificFilepath_fileSubfund]" +
                   $"( {entityId},'{chosenDate}',{fileTypeNavReport}) [FILEPATH]";
                }
                else if (controllerName == "ShareClasses")
                {
                    command.CommandText = $"select [dbo].[fn_getSpecificFilepath_fileShareclass]" +
                   $"( {entityId},'{chosenDate}',{fileTypeKiid}) [FILEPATH]";
                }

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

        public void AddDocumentToSpecificEntity(
                                    string fileName,
                                    int entityId,
                                    DateTime startConnection,
                                    DateTime? endConnection,
                                    int fileTypeId,
                                    string controllerName)
        {
            string query = string.Empty;

            if (controllerName == "Funds")
            {
                query = "EXEC sp_insert_map_fund " +
                  "@file_name, @entity_id, @start_connection, @end_connection, @filetype_id";
            }
            else if (controllerName == "SubFunds")
            {
                query = "EXEC sp_insert_map_subfund " +
               "@file_name, @entity_id, @start_connection, @end_connection, @filetype_id";
            }
            else if (controllerName == "ShareClasses")
            {
                query = "EXEC sp_insert_map_shareclass " +
               "@file_name, @entity_id, @start_connection, @end_connection, @filetype_id";
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar, 100) { Value = fileName },
                        new SqlParameter("@entity_id", SqlDbType.Int) { Value = entityId },
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

        public void AddAgreementToSpecificEntity(
                                    int entityId,
                                    int agrFileTypeId,
                                    DateTime contractDate,
                                    DateTime activationDate,
                                    DateTime? expirationDate,
                                    int statusId,
                                    int companyId,
                                    string fileName,
                                    string controllerName)
        {
            string query = string.Empty;

            if (controllerName == "Funds")
            {

            }
            else if (controllerName == "SubFunds")
            {
               
            }
            else if (controllerName == "ShareClasses")
            {
               
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar, 100) { Value = fileName },
                        //new SqlParameter("@entity_id", SqlDbType.Int) { Value = entityId },
                        //new SqlParameter("@start_connection", SqlDbType.NVarChar, 100) { Value = startConnection.ToString("yyyyMMdd") },
                        //new SqlParameter("@end_connection", SqlDbType.NVarChar, 100) { Value = endConnection?.ToString("yyyyMMdd") },
                        //new SqlParameter("@filetype_id", SqlDbType.Int) { Value = fileTypeId },
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