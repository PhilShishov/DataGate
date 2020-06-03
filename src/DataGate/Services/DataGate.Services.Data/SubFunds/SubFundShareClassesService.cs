namespace DataGate.Services.Data.SubFunds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.SubFunds.Contracts;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.ViewModels.Queries;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class SubFundShareClassesService : ISubFundShareClassesService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionSubEntities = "[fn_active_subfund_shareclasses]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryShareClass> repository;
        private readonly IRepository<TbSubFundShareClass> subsRepository;
        private readonly IConfiguration configuration;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public SubFundShareClassesService(
                    IConfiguration configuration,
                    ISqlQueryManager sqlQueryManager,
                    IRepository<TbHistoryShareClass> shareClassesRepository,
                    IRepository<TbSubFundShareClass> subFundShareClassrepository)
        {
            this.configuration = configuration;
            this.repository = shareClassesRepository;
            this.sqlManager = sqlQueryManager;
            this.subsRepository = subFundShareClassrepository;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public async IAsyncEnumerable<string[]> GetSubEntities(int id, DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryAsync(this.sqlFunctionSubEntities, date, id)
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
                .ExecuteQueryAsync(this.sqlFunctionSubEntities, dto.Date, dto.Id, resultColumns)
                .Skip(skip);

            query = CheckForTakeValue(take, query);

            await foreach (var item in query)
            {
                yield return item;
            }
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var subfundShareClasses = this.subsRepository.All();
            var shareclasses = this.repository.All();

            var query = await (from sc in shareclasses
                               join sfsc in subfundShareClasses on sc.ScId equals sfsc.ScId
                               where sfsc.ScId == id
                               select sc.ScOfficialShareClassName)
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

        private bool Exists(int id) => this.repository.All().Any(x => x.ScId == id);
    }
}
