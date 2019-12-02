// Service class for managing shareclasses

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.ShareClasses
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Pharus.Services.Contracts;
    using Pharus.Services.Utilities;

    // _____________________________________________________________
    public class ShareClassesService : IShareClassesService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public ShareClassesService(IConfiguration config)
        {
            this.configuration = config;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public List<string[]> GetAllActiveShareClasses()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclasses('{this.defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveShareClasses(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveShareClassById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclasses('{this.defaultDate}') where [ID] = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveShareClassById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{this.defaultDate}') where [ID] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_shareclasses('{chosenDate?.ToString("yyyyMMdd")}') where [ID] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveShareClassWithDateById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_shareclasses('{this.defaultDate}') where [ID] = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetShareClass_SubFundContainer(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                Dictionary<int, string> funds = new Dictionary<int, string>();

                command.CommandText = $"select * from fn_SubfundForShareclassAtDate('{this.defaultDate}', {id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetShareClass_SubFundContainer(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                Dictionary<int, string> funds = new Dictionary<int, string>();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_SubfundForShareclassAtDate('{this.defaultDate}', {id})";
                }

                else
                {
                    command.CommandText = $"select * from fn_SubfundForShareclassAtDate('{chosenDate?.ToString("yyyyMMdd")}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }
    }
}
