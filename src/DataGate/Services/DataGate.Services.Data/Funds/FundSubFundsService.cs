namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.SqlClient;

    public class FundSubFundsService : IFundSubFundsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAllFund = "fn_all_fund";
        private readonly string sqlFunctionSubFundPdfView = "fn_active_subfund_pdf";
        private readonly string sqlFunctionTimelineFund = "dbo.fn_timeline_fund";
        private readonly string sqlFunctionDistinctDocuments = "[dbo].[fn_view_distinct_documents_fund]";
        private readonly string sqlFunctionAllDocuments = "[dbo].[fn_view_documents_fund]";
        private readonly string sqlFunctionDistinctAgreements = "[dbo].[fn_view_distinct_agreements_fund]";
        private readonly string sqlFunctionAllAgreements = "[dbo].[fn_view_agreements_fund]";
        private readonly string sqlFunctionSubFundsForFund = "ActiveSubFundsForSpecificFundAtDate";

        private readonly string columnToPassToQuery = "FUND ID PHARUS";
        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryFund> repository;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FundSubFundsService(
                    ISqlQueryManager sqlQueryManager,
                    IRepository<TbHistoryFund> fundsRepository)
        {
            this.repository = fundsRepository;
            this.sqlManager = sqlQueryManager;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public IEnumerable<string[]> GetFundWithDateById(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteSqlQueryByWhereId(chosenDate, id, this.sqlFunctionAllFund, this.columnToPassToQuery);
        }

        public IEnumerable<string[]> GetFund_SubFunds(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string[]> GetFund_SubFundsWithSelectedViewAndDate(
                                                                    List<string> preSelectedColumns,
                                                                    List<string> selectedColumns,
                                                                    DateTime? chosenDate,
                                                                    int id)
        {
            return this.sqlManager.ExecuteSqlQueryByIdWithSelection(ref preSelectedColumns, selectedColumns, chosenDate, id, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string[]> GetFundTimeline(int id)
        {
            return this.sqlManager.ExecuteSqlQueryById(id, this.sqlFunctionTimelineFund);
        }

        public IEnumerable<string[]> GetDistinctFundDocuments(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionDistinctDocuments);
        }

        public IEnumerable<string[]> GetAllFundDocuments(int id)
        {
            return this.sqlManager.ExecuteSqlQueryById(id, this.sqlFunctionAllDocuments);
        }

        public IEnumerable<string[]> GetDistinctFundAgreements(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionDistinctAgreements);
        }

        public IEnumerable<string[]> GetAllFundAgreements(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteSqlQueryByDateAndId(chosenDate, id, this.sqlFunctionAllAgreements);
        }

        public IEnumerable<string[]> PrepareFund_SubFundsForPDFExtract(DateTime? chosenDate)
        {
            return this.sqlManager.ExecuteSqlQuery(chosenDate, this.sqlFunctionSubFundPdfView);
        }
    }
}
