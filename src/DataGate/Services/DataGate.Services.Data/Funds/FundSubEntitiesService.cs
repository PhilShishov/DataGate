namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class FundSubEntitiesService : IFundSubEntitiesService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAllFund = "[fn_all_fund]";
        private readonly string sqlFunctionFundId = "[fn_fund_id]";
        private readonly string sqlFunctionSubFundPdfView = "[fn_active_subfund_pdf]";
        private readonly string sqlFunctionTimelineFund = "[fn_timeline_fund]";
        private readonly string sqlFunctionDistinctDocuments = "[fn_view_distinct_documents_fund]";
        private readonly string sqlFunctionAllDocuments = "[fn_view_documents_fund]";
        private readonly string sqlFunctionDistinctAgreements = "[fn_view_distinct_agreements_fund]";
        private readonly string sqlFunctionAllAgreements = "[fn_view_agreements_fund]";
        private readonly string sqlFunctionSubFundsForFund = "[fn_active_fund_subfunds]";

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
            return this.sqlManager.ExecuteQuery(this.sqlFunctionFundId, date, id);
        }

        public IEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
                .ExecuteQuery(this.sqlFunctionSubFundsForFund, date, id)
                .Skip(skip);

            return query;
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
            return this.sqlManager.ExecuteQuery(this.sqlFunctionSubFundsForFund, date, id, selectedColumns);
        }

        public IEnumerable<string[]> GetTimeline(int id)
        {
            return this.sqlManager.ExecuteQueryById(id, this.sqlFunctionTimelineFund);
        }

        public IEnumerable<T> GetDistinctDocuments<T>(int id, DateTime? date)
        {
            var query = this.sqlManager
                .ExecuteQuery(this.sqlFunctionDistinctDocuments, date, id)
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

        public IEnumerable<T> GetAllDocuments<T>(int id)
        {
            this.sqlManager.ExecuteQueryById(id, this.sqlFunctionAllDocuments);

            IEnumerable<AllDocDto> dto = this.sqlManager.ExecuteQueryMapping<AllDocDto>(this.sqlFunctionDistinctAgreements, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date)
        {
            IEnumerable<DistinctDocDto> dto = this.sqlManager.ExecuteQueryMapping<DistinctDocDto>( this.sqlFunctionDistinctAgreements, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<string[]> GetAllAgreements(int id, DateTime? date)
        {
            return this.sqlManager.ExecuteQuery(this.sqlFunctionAllAgreements, date, id);
        }

        public IEnumerable<string[]> PrepareEntity_SubEntitiesForPdfExtract(DateTime? date)
        {
            return this.sqlManager.ExecuteQuery(this.sqlFunctionSubFundPdfView, date);
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
