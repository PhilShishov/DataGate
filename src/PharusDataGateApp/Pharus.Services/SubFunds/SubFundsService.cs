namespace Pharus.Services.SubFunds
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Pharus.Services.Utilities;
    using Pharus.Services.Contracts;

    public class SubFundsService : ISubFundsService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;

        public SubFundsService(IConfiguration config)
        {
            this.configuration = config;
        }

        public List<string[]> GetAllActiveSubFunds()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_subfund('{this.defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveSubFunds(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_subfund('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_subfund('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveSubFundById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_subfund('{this.defaultDate}') where [ID] = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveSubFundById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_subfund('{this.defaultDate}') where [ID] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_subfund('{chosenDate?.ToString("yyyyMMdd")}') where [ID] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveSubFundWithDateById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_subfund_modifyview('{this.defaultDate}') where [ID] = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetSubFundShareClasses(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from ActivesubfundforSpecificFundAtDate('{this.defaultDate}', {id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }
    }
}