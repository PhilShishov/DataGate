// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Service class for managing funds

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.ShareClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.ShareClasses.Contracts;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.ViewModels.Queries;

    using Microsoft.EntityFrameworkCore;

    // _____________________________________________________________
    public class ShareClassService : IShareClassService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionAll = "[fn_all_shareclass]";
        private readonly string sqlFunctionAllActive = "[fn_active_shareclass]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryShareClass> repository;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string,
        // IRepository to connect with dbcontext and
        // sql manager for executing queries
        public ShareClassService(
                        ISqlQueryManager sqlQueryManager,
                        IRepository<TbHistoryShareClass> repository)
        {
            this.sqlManager = sqlQueryManager;
            this.repository = repository;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public IEnumerable<string[]> GetAll(DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
                .ExecuteQuery(this.sqlFunctionAll, date)
                .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string[]> GetAllActive(DateTime? date, int? take, int skip)
        {
            var query = this.sqlManager
               .ExecuteQuery(this.sqlFunctionAllActive, date)
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
                .ExecuteQuery(this.sqlFunctionAll, dto.Date, null, resultColumns)
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
                .ExecuteQuery(this.sqlFunctionAllActive, dto.Date, null, resultColumns)
                .Skip(skip);
            query = CheckForTakeValue(take, query);

            return query;
        }

        public IEnumerable<string> GetHeaders()
        {
           return this.GetAllActive(null, 1, 0).FirstOrDefault();
        }

        public async Task<ISet<string>> GetNamesAsync(int? id)
        {
            var query = await this.repository
                .All()
                .OrderBy(x => x.ScOfficialShareClassName)
                .Select(f => f.ScOfficialShareClassName)
                .ToListAsync();

            return query.ToHashSet();
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
