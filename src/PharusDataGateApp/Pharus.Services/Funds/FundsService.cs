namespace Pharus.Services.Funds
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;
    using Pharus.Services.Utilities;

    public class FundsService : IFundsService
    {
        private readonly string defaultDate = DateTime.Today.ToString("yyyyMMdd");
        private readonly string ConnectionString = DbConfiguration.ConnectionStringPharus_vFinale.ToString();

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
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@f_id", SqlDbType.Int) { Value = fundId},
                        new SqlParameter("@f_initialDate", SqlDbType.VarChar, 100) { Value = chosenDate.ToString("yyyyMMdd")},
                        new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId},
                        new SqlParameter("@f_registrationNumber", SqlDbType.VarChar, 100) { Value = fundsValues[16]},
                        new SqlParameter("@f_officialFundName", SqlDbType.VarChar, 100) { Value = fundsValues[3]},
                        new SqlParameter("@f_shortFundName", SqlDbType.VarChar, 100) { Value = fundsValues[3]},
                        new SqlParameter("@f_leiCode", SqlDbType.VarChar, 100) { Value = fundsValues[15]},
                        new SqlParameter("@f_cssfCode", SqlDbType.VarChar, 100) { Value = fundsValues[4]},
                        new SqlParameter("@f_faCode", SqlDbType.VarChar, 100) { Value = fundsValues[9]},
                        new SqlParameter("@f_depCode", SqlDbType.VarChar, 100) { Value = fundsValues[10]},
                        new SqlParameter("@f_taCode", SqlDbType.VarChar, 100) { Value = fundsValues[11]},
                        new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId},
                        new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId},
                        new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId},
                        new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId},
                        new SqlParameter("@f_tinNumber", SqlDbType.VarChar, 100) { Value = fundsValues[14]}
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