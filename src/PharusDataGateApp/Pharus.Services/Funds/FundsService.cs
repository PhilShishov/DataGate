namespace Pharus.Services.Funds
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.Services.Utilities;
    using System.Globalization;
    using System.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Pharus.Domain.PharusProd;

    public class FundsService : IFundsService
    {
        PharusProdContext context;
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly string ConnectionString = DbConfiguration.ConnectionStringPharusProd.ToString();

        public FundsService(PharusProdContext context)
        {
            context = this.context;
        }

        public List<string[]> GetAllActiveFunds()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund('{defaultDate}')";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetAllActiveFunds(DateTime? chosenDate)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from fn_active_fund('{defaultDate}')";
                }

                else
                {
                    command.CommandText = $"select * from fn_active_fund('{chosenDate?.ToString("yyyyMMdd")}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveFundById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund('{defaultDate}') where [FUND ID PHARUS] = {Id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetActiveFundById(DateTime? chosenDate, int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
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
        public List<string[]> GetActiveFundWithDateById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from fn_active_fund_modifyview('{defaultDate}') where [FUND ID PHARUS] = {Id}";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public List<string[]> GetFundSubFunds(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"select * from ActivesubfundforSpecificFundAtDate('{defaultDate}', {Id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public void ExecuteEditFund(List<string> fundsValues, int fundId, DateTime chosenDate, int fStatusId,
                                                int fLegalFormId, int fLegalTypeId,
                                                int fLegalVehicleId, int fCompanyTypeId)
        {     
            string query = "EXEC sp_modify_fund @f_id, @f_initialDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber";

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.Add("@f_id", SqlDbType.Int);
                    command.Parameters.Add("@f_status", SqlDbType.Int);
                    command.Parameters.Add("@f_legalForm", SqlDbType.Int);
                    command.Parameters.Add("@f_legalType", SqlDbType.Int);
                    command.Parameters.Add("@f_legal_vehicle", SqlDbType.Int);
                    command.Parameters.Add("@f_companyType", SqlDbType.Int);

                    command.Parameters.Add("@f_initialDate", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_registrationNumber", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_officialFundName", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_shortFundName", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_leiCode", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_cssfCode", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_faCode", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_depCode", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_taCode", SqlDbType.VarChar, 100);
                    command.Parameters.Add("@f_tinNumber", SqlDbType.VarChar, 100);                    

                    command.Parameters["@f_id"].Value = fundId;
                    command.Parameters["@f_initialDate"].Value = chosenDate.ToString("yyyyMMdd");
                    command.Parameters["@f_status"].Value = fStatusId;
                    command.Parameters["@f_registrationNumber"].Value = fundsValues[16];
                    command.Parameters["@f_officialFundName"].Value = fundsValues[3];
                    command.Parameters["@f_shortFundName"].Value = fundsValues[3];
                    command.Parameters["@f_leiCode"].Value = fundsValues[15];
                    command.Parameters["@f_cssfCode"].Value = fundsValues[4];
                    command.Parameters["@f_faCode"].Value = fundsValues[9];
                    command.Parameters["@f_depCode"].Value = fundsValues[10];
                    command.Parameters["@f_taCode"].Value = fundsValues[11];
                    command.Parameters["@f_legalForm"].Value = fLegalFormId;
                    command.Parameters["@f_legalType"].Value = fLegalTypeId;
                    command.Parameters["@f_legal_vehicle"].Value = fLegalVehicleId;
                    command.Parameters["@f_companyType"].Value = fCompanyTypeId;
                    command.Parameters["@f_tinNumber"].Value = fundsValues[14];

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