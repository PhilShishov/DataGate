﻿namespace Pharus.Services
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Utilities;
    using Pharus.Services.Contracts;

    public class SubFundsService : ISubFundsService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");

        public SubFundsService()
        {
        }

        public List<string[]> GetAllActiveSubFunds()
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_subfund('{defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveSubFunds(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_subfund('{defaultDate}')";
                }

                else
                {
                    command.CommandText = $"select * from fn_active_subfund('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveSubFundById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund('{defaultDate}') where [FUND ID PHARUS] = {Id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveSubFundById(DateTime? chosenDate, int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_fund('{defaultDate}') where [FUND ID PHARUS] = {Id}";
                }

                else
                {
                    command.CommandText = $"select * from fn_active_fund('{chosenDate?.ToString("yyyyMMdd")}') where [FUND ID PHARUS] = {Id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetSubFundShareClasses(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConfiguration.ConnectionStringPharus_vFinale.ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from ActivesubfundforSpecificFundAtDate('{defaultDate}', {Id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }
    }
}
