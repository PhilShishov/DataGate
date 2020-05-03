// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;
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
        public IEnumerable<string[]> GetAll(DateTime? chosenDate, int? take, int skip)
        {
            var query = this.sqlManager
                .ExecuteQuery(chosenDate, this.sqlFunctionAllFund)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IEnumerable<string[]> GetAllActive(DateTime? chosenDate, int? take, int skip)
        {
            var query = this.sqlManager
               .ExecuteQuery(chosenDate, this.sqlFunctionAllActiveFund)
               .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IEnumerable<string[]> GetAllWithSelectedViewAndDate(
                                                                IReadOnlyCollection<string> preSelectedColumns,
                                                                IEnumerable<string> selectedColumns,
                                                                DateTime? chosenDate)
        {
            // Prepare items for DB query with []
            //preSelectedColumns.AddRange(selectedColumns);
            //selectedColumns = selectedColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col));

            return this.sqlManager.ExecuteQueryWithSelection(selectedColumns, chosenDate, this.sqlFunctionAllFund);
        }

        public IEnumerable<string[]> GetAllActiveWithSelectedViewAndDate(
                                                                    IReadOnlyCollection<string> preSelectedColumns,
                                                                    IEnumerable<string> selectedColumns,
                                                                    DateTime? chosenDate)
        {
            // Prepare items for DB query with []
            ((List<string>)selectedColumns).InsertRange(0, preSelectedColumns);

            selectedColumns = selectedColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col)).ToList();

            return this.sqlManager.ExecuteQueryWithSelection(selectedColumns, chosenDate, this.sqlFunctionAllActiveFund);
        }
    }
}
