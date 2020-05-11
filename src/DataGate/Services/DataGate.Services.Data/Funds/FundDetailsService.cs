﻿namespace DataGate.Services.Data.Funds
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

    public class FundDetailsService : IFundDetailsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionFundId = "[fn_fund_id]";
        private readonly string sqlFunctionDistinctDocuments = "[fn_view_distinct_documents_fund]";
        private readonly string sqlFunctionDistinctAgreements = "[fn_view_distinct_agreements_fund]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistorySubFund> repository;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public FundDetailsService(
                    ISqlQueryManager sqlQueryManager,
                    IRepository<TbHistorySubFund> subFundsRepository)
        {
            this.repository = subFundsRepository;
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
