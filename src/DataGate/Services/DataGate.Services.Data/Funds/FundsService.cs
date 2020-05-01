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
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient;

    using Microsoft.Extensions.Configuration;

    // _____________________________________________________________
    public class FundsService : IFundsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAllFund = "fn_all_fund";
        private readonly string sqlFunctionAllActiveFund = "fn_active_fund";

        private readonly IConfiguration configuration;
        private readonly IRepository<TbHistoryFund> fundsRepository;
        private readonly ISqlQueryManager sqlManager;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string,
        // IRepository to connect with dbcontext and
        // sql manager for executing queries
        public FundsService(
                        IConfiguration config,
                        IRepository<TbHistoryFund> fundsRepository,
                        ISqlQueryManager sqlQueryManager)
        {
            this.configuration = config;
            this.fundsRepository = fundsRepository;
            this.sqlManager = sqlQueryManager;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public IEnumerable<string[]> GetAll(DateTime? chosenDate)
        {
            return this.sqlManager.ExecuteSqlQuery(chosenDate, this.sqlFunctionAllFund);
        }

        public IEnumerable<string[]> GetAllActive()
        {
            return this.sqlManager.ExecuteSqlQuery(null, this.sqlFunctionAllActiveFund);
        }

        public IEnumerable<string[]> GetAllActive(DateTime? chosenDate)
        {
            return this.sqlManager.ExecuteSqlQuery(chosenDate, this.sqlFunctionAllActiveFund);
        }

        public IEnumerable<string[]> GetAllWithSelectedViewAndDate(
                                                                    List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate)
        {
            return this.sqlManager.ExecuteSqlQueryWithSelection(ref preSelectedColumns, selectedColumns, chosenDate, this.sqlFunctionAllFund);
        }

        public IEnumerable<string[]> GetAllActiveWithSelectedViewAndDate(
                                                                            List<string> preSelectedColumns,
                                                                            List<string> selectedColumns,
                                                                            DateTime? chosenDate)
        {
            return this.sqlManager.ExecuteSqlQueryWithSelection(ref preSelectedColumns, selectedColumns, chosenDate, this.sqlFunctionAllActiveFund);
        }

        public IEnumerable<T> GetAllNames<T>()
        {
            return this.fundsRepository
                .All()
                .Select(f => f.FOfficialFundName)
                .To<T>()
                .ToList();

            // return this.context.TbHistoryFund
            //   .Select(f => f.FOfficialFundName)
            //   .ToList();
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

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@f_id", SqlDbType.Int) { Value = fundId },
                        new SqlParameter("@comment", SqlDbType.NVarChar) { Value = comment },
                        new SqlParameter("@commentTitle", SqlDbType.NVarChar) { Value = commentTitle },
                    });

                    command.Parameters.AddRange(new[]
                    {
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
                    });

                    this.sqlManager.ExecuteScalarSqlConnectionCommand(connection, command);
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
                connection.ConnectionString = this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection);
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Parameters.Add(new SqlParameter("@f_endDate", SqlDbType.NVarChar) { Value = endDate });

                    command.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@f_initialDate", SqlDbType.NVarChar) { Value = initialDate },
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

                    this.sqlManager.ExecuteScalarSqlConnectionCommand(connection, command);
                }
            }
        }
    }
}
