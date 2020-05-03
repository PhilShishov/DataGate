namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.SqlClient.Contracts;

    public class FundSubEntitiesService : IFundSubEntitiesService
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
        public FundSubEntitiesService(
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
        public IEnumerable<string[]> GetEntityWithDateById(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteQueryByWhereId(chosenDate, id, this.sqlFunctionAllFund, this.columnToPassToQuery);
        }

        public IEnumerable<string[]> GetEntity_SubEntities(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteQueryByDateAndId(chosenDate, id, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string[]> GetEntity_SubEntitiesWithSelectedViewAndDate(
                                                                    IReadOnlyCollection<string> preSelectedColumns,
                                                                    IEnumerable<string> selectedColumns,
                                                                    DateTime? chosenDate,
                                                                    int id)
        {
            return this.sqlManager.ExecuteQueryByIdWithSelection(selectedColumns, chosenDate, id, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string[]> GetTimeline(int id)
        {
            return this.sqlManager.ExecuteQueryById(id, this.sqlFunctionTimelineFund);
        }

        public IEnumerable<string[]> GetDistinctDocuments(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteQueryByDateAndId(chosenDate, id, this.sqlFunctionDistinctDocuments);
        }

        public IEnumerable<string[]> GetAllDocuments(int id)
        {
            return this.sqlManager.ExecuteQueryById(id, this.sqlFunctionAllDocuments);
        }

        public IEnumerable<string[]> GetDistinctAgreements(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteQueryByDateAndId(chosenDate, id, this.sqlFunctionDistinctAgreements);
        }

        public IEnumerable<string[]> GetAllAgreements(DateTime? chosenDate, int id)
        {
            return this.sqlManager.ExecuteQueryByDateAndId(chosenDate, id, this.sqlFunctionAllAgreements);
        }

        public IEnumerable<string[]> PrepareEntity_SubEntitiesForPdfExtract(DateTime? chosenDate)
        {
            return this.sqlManager.ExecuteQuery(chosenDate, this.sqlFunctionSubFundPdfView);
        }

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);
    }
}