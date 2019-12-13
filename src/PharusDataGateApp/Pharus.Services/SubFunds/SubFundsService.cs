// Service class for managing subfunds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.SubFunds
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Utilities.Services;
    using Pharus.Services.SubFunds.Contracts;

    using Microsoft.Extensions.Configuration;

    // _____________________________________________________________
    public class SubFundsService : ISubFundsService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;
        private readonly Pharus_vFinale_Context context;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public SubFundsService(
            IConfiguration config,
            Pharus_vFinale_Context context)
        {
            this.configuration = config;
            this.context = context;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public List<string[]> GetAllSubFunds()
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

        public List<string[]> GetAllSubFunds(DateTime? chosenDate)
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

        public List<string> GetAllSubFundsNames()
        {
            return this.context.TbHistorySubFund
               .Select(f => f.SfOfficialSubFundName)
               .ToList();
        }

        public List<string[]> GetSubFundById(int id)
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

        public List<string[]> GetSubFundById(DateTime? chosenDate, int id)
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

        public List<string[]> GetSubFundWithDateById(int id)
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

        public List<string[]> GetSubFundWithDateById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_subfund_modifyview('{this.defaultDate}') where [ID] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_subfund_modifyview('{chosenDate?.ToString("yyyyMMdd")}') where [ID] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetSubFund_ShareClasses(int id)
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

        public List<string[]> GetSubFund_ShareClasses(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from ActivesubfundforSpecificFundAtDate('{this.defaultDate}', {id})";
                }
                else
                {
                    command.CommandText = $"select * from ActivesubfundforSpecificFundAtDate('{chosenDate?.ToString("yyyyMMdd")}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetSubFund_FundContainer(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                Dictionary<int, string> funds = new Dictionary<int, string>();

                command.CommandText = $"select * from fn_FundForSubfundAtDate('{this.defaultDate}', {id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetSubFund_FundContainer(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                Dictionary<int, string> funds = new Dictionary<int, string>();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_FundForSubfundAtDate('{this.defaultDate}', {id})";
                }

                else
                {
                    command.CommandText = $"select * from fn_FundForSubfundAtDate('{chosenDate?.ToString("yyyyMMdd")}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetSubFundTimeline(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from dbo.fn_timeline_subfund({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllSubFundDocumens(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from [dbo].[fn_viewdocuments_subfund]({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public void EditSubFund(
                                    int fundId,
                                    string initialDate,
                                    int fStatusId,
                                    string regNumber,
                                    string fundName,
                                    string leiCode,
                                    string cssfCode,
                                    string faCode,
                                    string depCode,
                                    string taCode,
                                    int fLegalFormId,
                                    int fLegalTypeId,
                                    int fLegalVehicleId,
                                    int fCompanyTypeId,
                                    string tinNumber,
                                    string comment,
                                    string commentTitle)
        {
            throw new NotImplementedException();
        }

        public void CreateSubFund(
                                    string initialDate,
                                    string endDate,
                                    string fundName,
                                    string cssfCode,
                                    int fStatusId,
                                    int fLegalFormId,
                                    int fLegalTypeId,
                                    int fLegalVehicleId,
                                    string faCode,
                                    string depCode,
                                    string taCode,
                                    int fCompanyTypeId,
                                    string tinNumber,
                                    string leiCode,
                                    string regNumber)
        {
            throw new NotImplementedException();
        }
    }
}