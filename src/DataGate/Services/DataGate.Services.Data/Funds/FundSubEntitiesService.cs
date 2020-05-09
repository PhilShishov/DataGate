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
    using DataGate.Web.ViewModels.Queries;

    public class FundSubEntitiesService : IFundSubEntitiesService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionFundId = "[fn_fund_id]";
        private readonly string sqlFunctionTimelineFund = "[fn_timeline_fund]";
        private readonly string sqlFunctionDistinctDocuments = "[fn_view_distinct_documents_fund]";
        private readonly string sqlFunctionDistinctAgreements = "[fn_view_distinct_agreements_fund]";
        private readonly string sqlFunctionSubFundsForFund = "[fn_active_fund_subfunds]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistorySubFund> repository;
        private readonly IRepository<TbFundSubFund> fundSubFundrepository;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FundSubEntitiesService(
                    ISqlQueryManager sqlQueryManager,
                    IRepository<TbHistorySubFund> subFundsRepository,
                    IRepository<TbFundSubFund> fundSubFundrepository)
        {
            this.repository = subFundsRepository;
            this.sqlManager = sqlQueryManager;
            this.fundSubFundrepository = fundSubFundrepository;
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

        public ISet<string> GetNames(int? id)
        {
            var fundSubfunds = this.fundSubFundrepository.All()
                .Where(fsf => fsf.FId == id);

            var subfunds = this.repository.All();

            var query = subfunds
                .Join(fundSubfunds, sf => sf.SfId, fsf => fsf.SfId, (sf, fsf) => sf)
                .Select(sf => sf.SfOfficialSubFundName)
                .ToHashSet();

            return query;
        }

        public IEnumerable<string[]> GetSubEntitiesSelected(GetWithSelectionDto dto, int? take, int skip)
        {
            return this.sqlManager.ExecuteQuery(this.sqlFunctionSubFundsForFund, dto.Date, dto.Id, dto.SelectedColumns);
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

        public IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date)
        {
            IEnumerable<DistinctDocDto> dto = this.sqlManager.ExecuteQueryMapping<DistinctDocDto>(this.sqlFunctionDistinctAgreements, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetTimeline<T>(int id)
        {
            IEnumerable<TimelineDto> dto = this.sqlManager.ExecuteQueryMapping<TimelineDto>(this.sqlFunctionTimelineFund, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.SfId == id);
    }
}
