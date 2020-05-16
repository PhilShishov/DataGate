namespace DataGate.Services.Data.Funds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.ViewModels.Queries;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class FundSubFundsService : IFundSubFundsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionSubFundsForFund = "[fn_active_fund_subfunds]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistorySubFund> repository;
        private readonly IRepository<TbFundSubFund> fundSubFundrepository;
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FundSubFundsService(
                    IConfiguration configuration,
                    ISqlQueryManager sqlQueryManager,
                    IRepository<TbHistorySubFund> subFundsRepository,
                    IRepository<TbFundSubFund> fundSubFundrepository)
        {
            this.configuration = configuration;
            this.repository = subFundsRepository;
            this.sqlManager = sqlQueryManager;
            this.fundSubFundrepository = fundSubFundrepository;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public async IAsyncEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryAsync(this.sqlFunctionSubFundsForFund, date, id)
                .Skip(skip);

            query = CheckForTakeValue(take, query);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<string[]> GetSubEntitiesSelected(GetWithSelectionDto dto, int? take, int skip)
        {
            // Create new collection to store
            // selected without change
            List<string> resultColumns = FormatSql.FormatColumns(dto.PreSelectedColumns, dto.SelectedColumns);

            var query = this.sqlManager
                .ExecuteQueryAsync(this.sqlFunctionSubFundsForFund, dto.Date, dto.Id, resultColumns)
                .Skip(skip);

            query = CheckForTakeValue(take, query);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var fundSubfunds = this.fundSubFundrepository.All();
            var subfunds = this.repository.All();

            var query = await (from sf in subfunds
                               join fsf in fundSubfunds on sf.SfId equals fsf.SfId
                               where fsf.FId == id
                               select sf.SfOfficialSubFundName)
                        .ToListAsync();

            return query.ToHashSet();
        }

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private static IAsyncEnumerable<string[]> CheckForTakeValue(int? take, IAsyncEnumerable<string[]> query)
        {
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.SfId == id);
    }
}
