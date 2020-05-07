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

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.ViewModels.Queries;

    // _____________________________________________________________
    public class FundsService : IFundsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAllFund = "[fn_all_fund]";
        private readonly string sqlFunctionAllActiveFund = "[fn_active_fund]";

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
        public IEnumerable<string[]> GetAll(DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
                .ExecuteQuery(this.sqlFunctionAllFund, date)
                .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string[]> GetAllActive(DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
               .ExecuteQuery(this.sqlFunctionAllActiveFund, date)
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
            List<string> resultColumns = FormatSql.FormatColumns(dto.PreSelectedColumns, dto.SelectedColumns);

            var query = this.sqlManager
                .ExecuteQuery(this.sqlFunctionAllFund, dto.Date, null, resultColumns)
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
            List<string> resultColumns = FormatSql.FormatColumns(dto.PreSelectedColumns, dto.SelectedColumns);

            var query = this.sqlManager
                .ExecuteQuery(this.sqlFunctionAllActiveFund, dto.Date, null, resultColumns)
                .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string> GetHeaders()
        {
            return this.GetAllActive(null, 1, 0).FirstOrDefault();
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
