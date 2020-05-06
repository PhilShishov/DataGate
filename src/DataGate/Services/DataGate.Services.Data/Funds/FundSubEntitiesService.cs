namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.ViewModels.Entities;

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
        public IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date)
        {
            return this.sqlManager.ExecuteQueryByWhereId(id, date, this.sqlFunctionAllFund, this.columnToPassToQuery);
        }

        public IEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take, int skip)
        {
            return this.sqlManager.ExecuteQueryByDateAndId(id, date, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string> GetHeaders(int id, DateTime? date)
        {
            return this.GetSubEntities(id, date, 1, 0).FirstOrDefault();
        }

        public IEnumerable<string[]> GetSubEntitiesSelected(
                                                                    int id,
                                                                    IReadOnlyCollection<string> preSelectedColumns,
                                                                    IEnumerable<string> selectedColumns,
                                                                    DateTime? date,
                                                                    int? take,
                                                                    int skip)
        {
            return this.sqlManager.ExecuteQueryByIdWithSelection(id, selectedColumns, date, this.sqlFunctionSubFundsForFund);
        }

        public IEnumerable<string[]> GetTimeline(int id)
        {
            return this.sqlManager.ExecuteQueryById(id, this.sqlFunctionTimelineFund);
        }

        public IEnumerable<T> GetDistinctDocuments<T>(int id, DateTime? date)
        {
            var query = this.sqlManager
                .ExecuteQueryByDateAndId(id, date, this.sqlFunctionDistinctDocuments)
                .ToList();

            var dto = new List<DistinctDocDto>();

            for (int row = 1; row < query.Count; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    var document = new DistinctDocDto
                    {
                        Name = query[row][col],
                    };
                    dto.Add(document);
                }
            }

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<string[]> GetAllDocuments(int id)
        {
            return this.sqlManager.ExecuteQueryById(id, this.sqlFunctionAllDocuments);
        }

        public IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date)
        {
            var query = this.sqlManager
                .ExecuteQueryByDateAndId(id, date, this.sqlFunctionDistinctAgreements)
               .ToList();

            var dto = new List<DistinctDocDto>();

            for (int row = 1; row < query.Count; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    var document = new DistinctDocDto
                    {
                        Description = query[row][col],
                        Name = query[row][col + 1],
                    };
                    dto.Add(document);
                }
            }

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<string[]> GetAllAgreements(int id, DateTime? date)
        {
            return this.sqlManager.ExecuteQueryByDateAndId(id, date, this.sqlFunctionAllAgreements);
        }

        public IEnumerable<string[]> PrepareEntity_SubEntitiesForPdfExtract(DateTime? date)
        {
            return this.sqlManager.ExecuteQuery(date, this.sqlFunctionSubFundPdfView);
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
