namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class EntityDetailsService : IEntityDetailsService
    {
        private readonly ISqlQueryManager sqlManager;

        public EntityDetailsService(ISqlQueryManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        public IAsyncEnumerable<string[]> ByIdAndDate(string function, int id, DateTime? date)
            => this.sqlManager.ExecuteQueryAsync(function, date, id);

        public ContainerDto GetContainer(string function, int id, DateTime? date)
             => this.sqlManager.ExecuteQueryMapping<ContainerDto>(function, id, date).FirstOrDefault();

        public async IAsyncEnumerable<string[]> GetSubEntities(string function, int? id, DateTime? date, int skip)
        {
            var query = this.sqlManager
                .ExecuteQueryAsync(function, date, id)
                .Skip(skip);

            await foreach (var item in query)
            {
                yield return item;
            }
        }
    }
}
