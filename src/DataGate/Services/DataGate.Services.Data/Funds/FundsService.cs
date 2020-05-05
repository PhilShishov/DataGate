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
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.ViewModels.Entities;

    // _____________________________________________________________
    public class FundsService : IFundsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAllFund = "fn_all_fund";
        private readonly string sqlFunctionAllActiveFund = "fn_active_fund";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryFund> repository;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string,
        // IRepository to connect with dbcontext and
        // sql manager for executing queries
        public FundsService(
                        ISqlQueryManager sqlQueryManager,
                        IRepository<TbHistoryFund> fundRepository)
        {
            this.sqlManager = sqlQueryManager;
            this.repository = fundRepository;
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
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string[]> GetAllActive(DateTime? chosenDate, int? take, int skip)
        {
            var query = this.sqlManager
               .ExecuteQuery(chosenDate, this.sqlFunctionAllActiveFund)
               .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string[]> GetAllSelected(
                                                                GetWithSelectionDto dto,
                                                                int? take,
                                                                int skip)
        {
            // Create new collection to store
            // selected without change
            List<string> resultColumns = PrepareResultForSelection(dto.PreSelectedColumns,dto.SelectedColumns);

            var query = this.sqlManager
                .ExecuteQueryWithSelection(resultColumns, dto.Date, this.sqlFunctionAllFund)
                .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string[]> GetAllActiveSelected(
                                                                    GetWithSelectionDto dto,
                                                                    int? take,
                                                                    int skip)
        {
            // Create new collection to store
            // selected without change
            List<string> resultColumns = PrepareResultForSelection(dto.PreSelectedColumns, dto.SelectedColumns);

            var query = this.sqlManager
                .ExecuteQueryWithSelection(resultColumns, dto.Date, this.sqlFunctionAllActiveFund)
                .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public ISet<string> GetNames()
        {
            HashSet<string> query = this.repository
                .All()
                .OrderBy(x => x.FOfficialFundName)
                .Select(f => f.FOfficialFundName)
                .ToHashSet();

            return query;
        }

        public T GetEntitiesOverview<T>()
        {
            var headers = this.GetAllActive(null, 1, 0);
            var values = this.GetAllActive(null, null, 1);

            var entity = new EntitiesOverviewGetDto()
            {
                IsActive = true,
                Date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                HeadersSelection = headers,
                Headers = headers,
                Values = values,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(entity);
        }

        private static List<string> PrepareResultForSelection(IReadOnlyCollection<string> preSelectedColumns, IEnumerable<string> selectedColumns)
        {
            List<string> resultColumns = new List<string>(preSelectedColumns);

            resultColumns.AddRange(selectedColumns);

            // Prepare items for DB query with []
            resultColumns = resultColumns.Select(col => string.Format(GlobalConstants.SqlItemFormatRequired, col)).ToList();
            return resultColumns;
        }

        private static IEnumerable<string[]> CheckForTakeValue(int? take, IEnumerable<string[]> query)
        {
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
