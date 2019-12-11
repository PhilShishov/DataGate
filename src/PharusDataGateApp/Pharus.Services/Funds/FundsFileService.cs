namespace Pharus.Services.Funds
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using Microsoft.Extensions.Configuration;

    using Pharus.Services.Funds.Contracts;

    public class FundsFileService : IFundsFileService
    {
        private const int fileTypeProspectus = 2;

        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FundsFileService(IConfiguration config)
        {
            this.configuration = config;
        }

        public string LoadFileToDisplay(int fundId, string chosenDate)
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

        public string GetStreamIdFromFileName(string fileName)
        {
            string streamId = string.Empty;
            SqlDataReader dataReader;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select cast(stream_id as nvarchar(MAX)) as [Stream Id] " +
                    $"from [Pharus_File_Development].[dbo].[FundFile] where [name]='{fileName}'";

                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    streamId = (string)dataReader["Stream Id"];

                    // Throw exception for null columns

                }
                dataReader.Close();
                return streamId;
            }
        }

        public void AddFileToSpecificFund(
                                    string streamId,
                                    int fundId,
                                    string startConnection,
                                    string endConnection,
                                    int fileTypeId)
        {
            string query = "EXEC sp_insert_map_fund " +
                "@stream_id, @fund_id, @start_connection, @end_connection, @filetype_id";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@stream_id", SqlDbType.NVarChar) { Value = streamId },
                        new SqlParameter("@fund_id", SqlDbType.Int) { Value = fundId },
                        new SqlParameter("@start_connection", SqlDbType.NVarChar, 100) { Value = startConnection },
                        new SqlParameter("@end_connection", SqlDbType.NVarChar, 100) { Value = endConnection },
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