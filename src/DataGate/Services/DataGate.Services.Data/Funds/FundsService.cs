// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.Funds.Contracts;

    using Microsoft.Extensions.Configuration;

    // _____________________________________________________________
    public class FundsService : IFundsService
    {
        private readonly string defaultDateTimeWithSqlConversion = DateTime.Today.ToString("yyyyMMdd");
        private readonly string sqlFunctionAllFund = "fn_all_fund";
        private readonly string sqlFunctionAllActiveFund = "fn_active_fund";
        private readonly string sqlFunctionSubFundPdfView = "fn_active_subfund_pdf";
        private readonly string sqlFunctionTimelineFund = "dbo.fn_timeline_fund";
        private readonly string sqlFunctionDistinctDocuments = "[dbo].[fn_view_distinct_documents_fund]";
        private readonly string sqlFunctionAllDocuments = "[dbo].[fn_view_documents_fund]";
        private readonly string sqlFunctionDistinctAgreements = "[dbo].[fn_view_distinct_agreements_fund]";
        private readonly string sqlFunctionAllAgreements = "[dbo].[fn_view_agreements_fund]";
        private readonly string sqlFunctionSubFundsForFund = "ActiveSubFundsForSpecificFundAtDate";

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
        public IEnumerable<string[]> GetAllFunds(DateTime? chosenDate)
        {
            return this.ExecuteSqlQuery(chosenDate, this.sqlFunctionAllFund);
        }

        public IEnumerable<string[]> GetAllActiveFunds()
        {
            return this.ExecuteSqlQuery(null, this.sqlFunctionAllActiveFund);
        }

        public IEnumerable<string[]> GetAllActiveFunds(DateTime? chosenDate)
        {
            return this.ExecuteSqlQuery(chosenDate, this.sqlFunctionAllActiveFund);
        }

        public IEnumerable<string[]> GetAllFundsWithSelectedViewAndDate(
                                                                    List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate)
        {
            return this.ExecuteSqlQueryWithSelection(ref preSelectedColumns, selectedColumns, chosenDate, this.sqlFunctionAllFund);
        }

        public IEnumerable<string[]> GetAllActiveFundsWithSelectedViewAndDate(
                                                                            List<string> preSelectedColumns,
                                                                            List<string> selectedColumns,
                                                                            DateTime? chosenDate)
        {
            return this.ExecuteSqlQueryWithSelection(ref preSelectedColumns, selectedColumns, chosenDate, this.sqlFunctionAllActiveFund);
        }

        //public List<string> GetAllFundsNames()
        //{
        //    return this.context.TbHistoryFund
        //        .Select(f => f.FOfficialFundName)
        //        .ToList();
        //}

        public IEnumerable<string[]> GetFundWithDateById(DateTime? chosenDate, int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from {this.sqlFunctionAllFund}('{this.defaultDateTimeWithSqlConversion}') where [FUND ID PHARUS] = {id}";
                }
                else
                {
                    command.CommandText = $"select * from {this.sqlFunctionAllFund}('{chosenDate?.ToString(GlobalConstants.SqlDateTimeFormatRequired)}') " +
                        $"where [FUND ID PHARUS] = {id}";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> GetFund_SubFunds(DateTime? chosenDate, int id)
        {
            return this.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string[]> GetFund_SubFundsWithSelectedViewAndDate(
                                                                    List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate,
                                                                    int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                // Prepare items for DB query with []
                preSelectedColumns.AddRange(selectedColumns);
                preSelectedColumns = preSelectedColumns.Select(c => string.Format(GlobalConstants.SqlItemFormatRequired, c)).ToList();

                if (chosenDate == null)
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {this.sqlFunctionSubFundsForFund}('{this.defaultDateTimeWithSqlConversion}', {id}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {this.sqlFunctionSubFundsForFund}('{chosenDate?.ToString(GlobalConstants.SqlDateTimeFormatRequired)}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        public IEnumerable<string[]> GetFundTimeline(int id)
        {
            return this.ExecuteSqlQueryById(id, this.sqlFunctionTimelineFund);
        }

        public IEnumerable<string[]> GetDistinctFundDocuments(DateTime? chosenDate, int id)
        {
            return this.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionDistinctDocuments);
        }

        public IEnumerable<string[]> GetAllFundDocuments(int id)
        {
            return this.ExecuteSqlQueryById(id, this.sqlFunctionAllDocuments);
        }

        public IEnumerable<string[]> GetDistinctFundAgreements(DateTime? chosenDate, int id)
        {
            return this.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionDistinctAgreements);
        }

        public IEnumerable<string[]> GetAllFundAgreements(DateTime? chosenDate, int id)
        {
            return this.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionAllAgreements);
        }

        public IEnumerable<string[]> PrepareFund_SubFundsForPDFExtract(DateTime? chosenDate)
        {
            return this.ExecuteSqlQuery(chosenDate, this.sqlFunctionSubFundPdfView);
        }

        // ________________________________________________________
        //
        // Execute query table DB based stored procedure
        // with fixed parameters
        public void EditFund(
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
            string query = "EXEC sp_modify_fund " +
                "@f_id, @f_initialDate, @f_status, " +
                "@f_registrationNumber, @f_officialFundName, @f_shortFundName, " +
                "@f_leiCode, @f_cssfCode, @f_faCode, @f_depCode, @f_taCode, " +
                "@f_legalForm, @f_legalType, @f_legal_vehicle, @f_companyType, @f_tinNumber, " +
                "@comment, @commentTitle";

            NewMethod(fundId, initialDate, fStatusId, regNumber, fundName, leiCode, cssfCode, faCode, depCode, taCode, fLegalFormId, fLegalTypeId, fLegalVehicleId, fCompanyTypeId, tinNumber, comment, commentTitle, query);
        }

        private void NewMethod(int fundId, string initialDate, int fStatusId, string regNumber, string fundName, string leiCode, string cssfCode, string faCode, string depCode, string taCode, int fLegalFormId, int fLegalTypeId, int fLegalVehicleId, int fCompanyTypeId, string tinNumber, string comment, string commentTitle, string query)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString("Pharus_vFinaleConnection");
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@f_id", SqlDbType.Int) { Value = fundId },
                        new SqlParameter("@f_initialDate", SqlDbType.NVarChar) { Value = initialDate },
                        new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId },
                        new SqlParameter("@f_registrationNumber", SqlDbType.NVarChar) { Value = regNumber },
                        new SqlParameter("@f_officialFundName", SqlDbType.NVarChar) { Value = fundName },
                        new SqlParameter("@f_shortFundName", SqlDbType.NVarChar) { Value = fundName },
                        new SqlParameter("@f_leiCode", SqlDbType.NVarChar) { Value = leiCode },
                        new SqlParameter("@f_cssfCode", SqlDbType.NVarChar) { Value = cssfCode },
                        new SqlParameter("@f_faCode", SqlDbType.NVarChar) { Value = faCode },
                        new SqlParameter("@f_depCode", SqlDbType.NVarChar) { Value = depCode },
                        new SqlParameter("@f_taCode", SqlDbType.NVarChar) { Value = taCode },
                        new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId },
                        new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId },
                        new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId },
                        new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId },
                        new SqlParameter("@f_tinNumber", SqlDbType.NVarChar) { Value = tinNumber },
                        new SqlParameter("@comment", SqlDbType.NVarChar) { Value = comment },
                        new SqlParameter("@commentTitle", SqlDbType.NVarChar) { Value = commentTitle },
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
            string query = "EXEC sp_new_fund " +
                "@f_initialDate, @f_endDate, @f_status, " +
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
                        new SqlParameter("@f_initialDate", SqlDbType.NVarChar) { Value = initialDate},
                        new SqlParameter("@f_endDate", SqlDbType.NVarChar) { Value = endDate},
                        new SqlParameter("@f_status", SqlDbType.Int) { Value = fStatusId },
                        new SqlParameter("@f_registrationNumber", SqlDbType.NVarChar) { Value = regNumber },
                        new SqlParameter("@f_officialFundName", SqlDbType.NVarChar) { Value = fundName },
                        new SqlParameter("@f_leiCode", SqlDbType.NVarChar) { Value = leiCode },
                        new SqlParameter("@f_cssfCode", SqlDbType.NVarChar) { Value = cssfCode },
                        new SqlParameter("@f_faCode", SqlDbType.NVarChar) { Value = faCode },
                        new SqlParameter("@f_depCode", SqlDbType.NVarChar) { Value = depCode },
                        new SqlParameter("@f_taCode", SqlDbType.NVarChar) { Value = taCode },
                        new SqlParameter("@f_legalForm", SqlDbType.Int) { Value = fLegalFormId },
                        new SqlParameter("@f_legalType", SqlDbType.Int) { Value = fLegalTypeId },
                        new SqlParameter("@f_legal_vehicle", SqlDbType.Int) { Value = fLegalVehicleId },
                        new SqlParameter("@f_companyType", SqlDbType.Int) { Value = fCompanyTypeId },
                        new SqlParameter("@f_tinNumber", SqlDbType.NVarChar) { Value = tinNumber },
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

        private IEnumerable<string[]> ExecuteSqlQuery(DateTime? chosenDate, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}')";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{chosenDate?.ToString(GlobalConstants.SqlDateTimeFormatRequired)}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        private IEnumerable<string[]> ExecuteSqlQueryWithSelection(
                                                                    ref List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate,
                                                                    string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                // Prepare items for DB query with []
                preSelectedColumns.AddRange(selectedColumns);
                preSelectedColumns = preSelectedColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col)).ToList();

                if (chosenDate == null)
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {function}('{this.defaultDateTimeWithSqlConversion}')";
                }
                else
                {
                    command.CommandText = $"select {string.Join(", ", preSelectedColumns)} from {function}('{chosenDate?.ToString(GlobalConstants.SqlDateTimeFormatRequired)}')";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        private IEnumerable<string[]> ExecuteSqlQueryByDateAndId(DateTime? chosenDate, int id, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                if (chosenDate == null)
                {
                    command.CommandText = $"select * from {function}('{this.defaultDateTimeWithSqlConversion}', {id})";
                }
                else
                {
                    command.CommandText = $"select * from {function}('{chosenDate?.ToString(GlobalConstants.SqlDateTimeFormatRequired)}', {id})";
                }

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        private IEnumerable<string[]> ExecuteSqlQueryById(int id, string function)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = this.SetUpSqlConnectionCommand(connection);

                command.CommandText = $"select * from {function}({id})";

                return CreateModel.CreateModelWithHeadersAndValue(command);
            }
        }

        private SqlCommand SetUpSqlConnectionCommand(SqlConnection connection)
        {
            connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            return command;
        }
    }
}
