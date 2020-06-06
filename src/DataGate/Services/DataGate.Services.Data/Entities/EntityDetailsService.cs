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

        public IAsyncEnumerable<string[]> GetByIdAndDate(string function, int id, DateTime? date)
            => this.sqlManager.ExecuteQueryAsync(function, date, id);

        public ContainerDto GetContainer(string function, int id, DateTime? date)
             => this.sqlManager.ExecuteQueryMapping<ContainerDto>(function, id, date).FirstOrDefault();
    }
}
