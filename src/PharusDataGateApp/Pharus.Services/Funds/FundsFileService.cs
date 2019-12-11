namespace Pharus.Services.Funds
{
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

                command.CommandText = $"select [dbo].[fn_getSpecificFilepath_filefund]( {fundId},'{chosenDate}',{fileTypeProspectus}) [FILEPATH]";

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

        public void InsertFundFile(int fundId, string chosenDate)
        {
            SqlDataReader dataReader;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select [dbo].[fn_getSpecificFilepath_filefund]( {fundId},'{chosenDate}',{fileTypeProspectus}) [FILEPATH]";

                dataReader = command.ExecuteReader();

                dataReader.Close();
            }
        }
    }
}