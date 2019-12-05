// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.Funds
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Pharus.Services.Utilities;
    using Pharus.Services.Funds.Contracts;

    // _____________________________________________________________
    public class FundsService : IFundsService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FundsService(IConfiguration config)
        {
            this.configuration = config;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public List<string[]> GetAllFunds()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund('{this.defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllFunds(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_fund('{this.defaultDate}')";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_fund('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetFundById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund('{this.defaultDate}') where [FUND ID PHARUS] = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetFundById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_fund('{this.defaultDate}') where [FUND ID PHARUS] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_fund('{chosenDate?.ToString("yyyyMMdd")}') where [FUND ID PHARUS] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetFundWithDateById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund_modifyview('{this.defaultDate}') where [FUND ID PHARUS] = {id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetFundWithDateById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_fund_modifyview('{this.defaultDate}') where [FUND ID PHARUS] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from fn_active_fund_modifyview('{chosenDate?.ToString("yyyyMMdd")}') where [FUND ID PHARUS] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetFund_SubFunds(int id)
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

        public List<string[]> GetFund_SubFunds(DateTime? chosenDate, int id)
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

        public List<string[]> GetFundTimeline(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from dbo.fn_timeline_fund({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        // ________________________________________________________
        //
        // Execute query table DB based stored procedure
        // with fixed parameters
        public void EditFund(
                                    List<string> fundsValues,
                                    int fundId,
                                    DateTime chosenDate,
                                    int fStatusId,
                                    int fLegalFormId,
                                    int fLegalTypeId,
                                    int fLegalVehicleId,
                                    int fCompanyTypeId)
        {
            string query = "EXEC sp_modify_fund @f_id, @f_initialDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@f_id", SqlDbType.Int) { Value = fundId },
                        new SqlParameter("@f_initialDate", SqlDbType.VarChar, 100) { Value = chosenDate.ToString("yyyyMMdd") },
                        new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId },
                        new SqlParameter("@f_registrationNumber", SqlDbType.VarChar, 100) { Value = fundsValues[16] },
                        new SqlParameter("@f_officialFundName", SqlDbType.VarChar, 100) { Value = fundsValues[3] },
                        new SqlParameter("@f_shortFundName", SqlDbType.VarChar, 100) { Value = fundsValues[3] },
                        new SqlParameter("@f_leiCode", SqlDbType.VarChar, 100) { Value = fundsValues[15] },
                        new SqlParameter("@f_cssfCode", SqlDbType.VarChar, 100) { Value = fundsValues[4] },
                        new SqlParameter("@f_faCode", SqlDbType.VarChar, 100) { Value = fundsValues[9] },
                        new SqlParameter("@f_depCode", SqlDbType.VarChar, 100) { Value = fundsValues[10] },
                        new SqlParameter("@f_taCode", SqlDbType.VarChar, 100) { Value = fundsValues[11] },
                        new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId },
                        new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId },
                        new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId },
                        new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId },
                        new SqlParameter("@f_tinNumber", SqlDbType.VarChar, 100) { Value = fundsValues[14] },
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

        public void CreateFund(
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
            string query = "EXEC sp_new_fund @f_initialDate, @f_endDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@f_initialDate", SqlDbType.VarChar, 100) { Value = initialDate},
                        new SqlParameter("@f_endDate", SqlDbType.VarChar, 100) { Value = endDate},
                        new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId },
                        new SqlParameter("@f_registrationNumber", SqlDbType.VarChar, 100) { Value = regNumber },
                        new SqlParameter("@f_officialFundName", SqlDbType.VarChar, 100) { Value = fundName },
                        new SqlParameter("@f_leiCode", SqlDbType.VarChar, 100) { Value = leiCode },
                        new SqlParameter("@f_cssfCode", SqlDbType.VarChar, 100) { Value = cssfCode },
                        new SqlParameter("@f_faCode", SqlDbType.VarChar, 100) { Value = faCode },
                        new SqlParameter("@f_depCode", SqlDbType.VarChar, 100) { Value = depCode },
                        new SqlParameter("@f_taCode", SqlDbType.VarChar, 100) { Value = taCode },
                        new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId },
                        new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId },
                        new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId },
                        new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId },
                        new SqlParameter("@f_tinNumber", SqlDbType.VarChar, 100) { Value = tinNumber },
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
