namespace Pharus.Services.Funds
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Funds.Contracts;

    public class FundsFileService : IFundsFileService
    {

        public string LoadFilePath(string fileName)
        {
            string filePath = string.Empty;
            SqlDataReader dataReader;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DbConfiguration.ConnectionStringPharusFiles;
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "select dbo.[fn_getFilePathFund]('PHARUS SICAV - Prospectus June 2019_VISA.pdf') [FILEPATH]";

                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    filePath = (string)dataReader["FILEPATH"];
                }

                dataReader.Close();
                return filePath;
            }
        }

        public List<string> LoadFilesNames(string chosenDate)
        {
            SqlDataReader dataReader;
            List<string> fileNames = new List<string>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = DbConfiguration.ConnectionStringPharusFiles;
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                // Correct query to insert
                command.CommandText = "select dbo.[fn_getFilePathFund]('PHARUS SICAV - Prospectus June 2019_VISA.pdf') [FILEPATH]";

                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fileNames = (List<string>)dataReader["name"];
                }

                dataReader.Close();
                return fileNames;
            }
        }
    }
}