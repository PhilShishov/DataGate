namespace DataGate.Services.Data.ShareClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.ShareClasses.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class ShareClassDetailsService : IShareClassDetailsService
    {
        // ________________________________________________________
        //
        // Table functions names as in DB
        private readonly string sqlFunctionById = "[fn_shareclass_id]";
        private readonly string sqlFunctionDistinctDocuments = "[fn_view_distinct_documents_shareclass]";
        private readonly string sqlFunctionDistinctAgreements = "[fn_view_distinct_agreements_shareclass]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistoryShareClass> repository;

        // ________________________________________________________
        //
        // Constructor: initialize with DI IConfiguration
        // to retrieve appsettings.json connection string
        public ShareClassDetailsService(
                    ISqlQueryManager sqlQueryManager,
                    IRepository<TbHistoryShareClass> repository)
        {
            this.repository = repository;
            this.sqlManager = sqlQueryManager;
        }

        // ________________________________________________________
        //
        // Retrieve query table DB based entities
        // with table functions
        public IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date)
        {
            return this.sqlManager.ExecuteQuery(this.sqlFunctionById, date, id);
        }

        public Task<string> GetContainer(int id, DateTime? date)
        {
            throw new NotImplementedException();
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
                        FileId = int.Parse(query[row][col + 1]),
                    };
                    dto.Add(document);
                }
            }

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetDistinctAgreements<T>(int id, DateTime? date)
        {
            IEnumerable<DistinctAgrDto> dto = this.sqlManager.ExecuteQueryMapping<DistinctAgrDto>(this.sqlFunctionDistinctAgreements, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistoryFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.ScId == id);
    }
}
