namespace Pharus.Services.Agreements
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Pharus.Utilities.Services;
    using Pharus.Services.Agreements.Contracts;

    public class AgreementsService : IAgreementsService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;

        public AgreementsService(
           IConfiguration config)
        {
            this.configuration = config;
        }

        public List<string[]> GetAgreementsForAllFunds(DateTime chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_view_agreements_all_funds('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_view_agreements_all_funds('{chosenDate.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAgreementsForAllSubFunds(DateTime chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_view_agreements_all_subfunds('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_view_agreements_all_subfunds('{chosenDate.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAgreementsForAllShareClasses(DateTime chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_view_agreements_all_shareclasses('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_view_agreements_all_shareclasses('{chosenDate.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }
    }
}