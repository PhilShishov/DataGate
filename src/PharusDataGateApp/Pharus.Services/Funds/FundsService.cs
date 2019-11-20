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
            CheckIfNull(fundsValues);

            string query = $"EXEC sp_modify_fund {fundId}, '{chosenDate.ToString("yyyyMMdd")}', " +
                    $"{fStatusId}, {fundsValues[16]}, {fundsValues[3]}, {fundsValues[3]}, " +
                    $"{fundsValues[15]}, {fundsValues[4]}, {fundsValues[9]}, " +
                    $"{fundsValues[10]}, {fundsValues[11]}, {fLegalFormId}, {fLegalTypeId}, {fLegalVehicleId}, " +
                    $"{fCompanyTypeId}, {fundsValues[14]}";

            //using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            //{
            //    SqlCommand command = connection.CreateCommand();
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = $"EXEC sp_modify_fund {fundId}, '{chosenDate.ToString("yyyyMMdd")}', " +
            //        $"{fStatusId}, {fundsValues[16]}, {fundsValues[3]}, {fundsValues[3]}, " +
            //        $"{fundsValues[15]}, {fundsValues[4]}, {fundsValues[9]}, " +
            //        $"{fundsValues[10]}, {fundsValues[11]}, {fLegalFormId}, {fLegalTypeId}, {fLegalVehicleId}, " +
            //        $"{fCompanyTypeId}, {fundsValues[14]}";

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
        }

        private static void CheckIfNull(List<string> fundsValues)
        {
            for (int i = 0; i < fundsValues.Count; i++)
            {
                if (string.IsNullOrEmpty(fundsValues[i]))
                {
                    fundsValues[i] = "null";
                }

                else
                {
                    fundsValues[i] = "'" + $"{fundsValues[i]}" + "'";
                }
            }
        }
    }
}