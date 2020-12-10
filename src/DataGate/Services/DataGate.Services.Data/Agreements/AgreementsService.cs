namespace DataGate.Services.Data.Agreements
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Data.Agreements.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class AgreementsService : IAgreementsService
    {
        private readonly ISqlQueryManager sqlManager;

        public AgreementsService(ISqlQueryManager sqlQueryManager)
        {
            this.sqlManager = sqlQueryManager;
        }

        public IEnumerable<T> All<T>(string function, DateTime date)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<AgreementLibraryDto>(function, null, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
