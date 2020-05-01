// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.SqlClient.Contracts;

    // _____________________________________________________________
    public class FundsService : IFundsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAllFund = "fn_all_fund";
        private readonly string sqlFunctionAllActiveFund = "fn_active_fund";

        private readonly ISqlQueryManager sqlManager;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string,
        // IRepository to connect with dbcontext and
        // sql manager for executing queries
        public FundsService(ISqlQueryManager sqlQueryManager)
        {
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
    }
}
