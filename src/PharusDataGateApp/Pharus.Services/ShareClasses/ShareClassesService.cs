namespace Pharus.Services.ShareClasses
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.Services.Utilities;

    public class ShareClassesService : IShareClassesService
    {
        private string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly string ConnectionString = DbConfiguration.ConnectionStringPharus_vFinale.ToString();        

        public List<string[]> GetAllActiveShareClasses()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclasses('{defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            };
        }

        public List<string[]> GetAllActiveShareClasses(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{defaultDate}')";
                }

                else
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveShareClassById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclasses('{defaultDate}') where [ID] = {Id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveShareClassById(DateTime? chosenDate, int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{defaultDate}') where [ID] = {Id}";
                }

                else
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{chosenDate?.ToString("yyyyMMdd")}') where [ID] = {Id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveShareClassWithDateById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclasses('{defaultDate}') where [ID] = {Id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }
    }
}
