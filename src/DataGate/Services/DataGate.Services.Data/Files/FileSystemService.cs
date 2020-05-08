namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using DataGate.Services.Data.Files;

    using Microsoft.Extensions.Configuration;

    public class FileSystemService : IFileSystemService
    {
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FileSystemService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void AddDocumentToSpecificEntity(
                                    string fileName,
                                    int entityId,
                                    string startConnection,
                                    string endConnection,
                                    string fileExt,
                                    int fileTypeId,
                                    string controllerName)
        {
            string query = string.Empty;

            if (controllerName == "Funds")
            {
                query = "EXEC sp_insert_map_fund " +
                  "@file_name, @entity_id, @start_connection, @end_connection, @file_ext, @filetype_id";
            }
            else if (controllerName == "SubFunds")
            {
                query = "EXEC sp_insert_map_subfund " +
               "@file_name, @entity_id, @start_connection, @end_connection, @file_ext, @filetype_id";
            }
            else if (controllerName == "ShareClasses")
            {
                query = "EXEC sp_insert_map_shareclass " +
               "@file_name, @entity_id, @start_connection, @end_connection, @file_ext, @filetype_id";
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = fileName },
                        new SqlParameter("@entity_id", SqlDbType.Int) { Value = entityId },
                        new SqlParameter("@start_connection", SqlDbType.NVarChar) { Value = startConnection },
                        new SqlParameter("@end_connection", SqlDbType.NVarChar) { Value = endConnection },
                        new SqlParameter("@file_ext", SqlDbType.NVarChar) { Value = fileExt },
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
                                    string fileName,
                                    string fileExt,
                                    int entityId,
                                    int activityTypeId,
                                    string contractDate,
                                    string activationDate,
                                    string expirationDate,
                                    int statusId,
                                    int companyId,
                                    string controllerName)
        {
            string query = string.Empty;

            if (controllerName == "Funds")
            {
                query = "EXEC sp_insert_agreement_fund " +
                  "@file_name, @entity_id, @file_ext, @activity_type_id, @contract_date, " +
                  "@activation_date, @expiration_date, @company_id, @status";
            }
            else if (controllerName == "SubFunds")
            {
                query = "EXEC sp_insert_agreement_subfund " +
                  "@file_name, @entity_id, @file_ext, @activity_type_id, @contract_date, " +
                  "@activation_date, @expiration_date, @company_id, @status";
            }
            else if (controllerName == "ShareClasses")
            {
                query = "EXEC sp_insert_agreement_shareclass " +
                  "@file_name, @entity_id, @file_ext, @activity_type_id, @contract_date, " +
                  "@activation_date, @expiration_date, @company_id, @status";
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = fileName },
                        new SqlParameter("@entity_id", SqlDbType.Int) { Value = entityId },
                        new SqlParameter("@file_ext", SqlDbType.NVarChar) { Value = fileExt },
                        new SqlParameter("@activity_type_id", SqlDbType.Int) { Value =  activityTypeId},
                        new SqlParameter("@contract_date", SqlDbType.NVarChar) { Value = contractDate },
                        new SqlParameter("@activation_date", SqlDbType.NVarChar) { Value = activationDate },
                        new SqlParameter("@expiration_date", SqlDbType.NVarChar) { Value = expirationDate },
                        new SqlParameter("@company_id", SqlDbType.Int) { Value = companyId },
                        new SqlParameter("@status", SqlDbType.Int) { Value = statusId },
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

        public void DeleteMapping(string docValue,string agrValue, string controllerName)
        {
            string query = string.Empty;

            // Documents
            if (controllerName == "SubFunds")
            {
                query = "EXEC delete_subfund_file_byname @file_name";
            }
            else if (controllerName == "ShareClasses")
            {
                query = "EXEC delete_shareclass_file_byname @file_name";
            }

            // Agreements
            if (controllerName == "Funds")
            {
                query = "EXEC delete_agreement_fundfile_byname @file_name";
            }
            else if (controllerName == "SubFunds")
            {
                query = "EXEC delete_agreement_subfundfile_byname @file_name";
            }
            else if (controllerName == "ShareClasses")
            {
                query = "EXEC delete_agreement_shareclassfile_byname @file_name";
            }

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@file_name", SqlDbType.NVarChar) { Value = docValue },
                    });

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
