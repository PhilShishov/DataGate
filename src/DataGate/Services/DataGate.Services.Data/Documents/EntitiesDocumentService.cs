// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Documents
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class EntitiesDocumentService : IEntitiesDocumentService
    {
        private readonly ISqlQueryManager sqlManager;

        public EntitiesDocumentService(ISqlQueryManager sqlQueryManager)
        {
            this.sqlManager = sqlQueryManager;
        }

        public IEnumerable<T> GetDistinctDocuments<T>(string function, int id, DateTime? date)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<DistinctDocDto>(function, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetDistinctAgreements<T>(string function, int id, DateTime? date)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<DistinctAgrDto>(function, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetAgreements<T>(string function, int id, DateTime? date)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<AgreementDto>(function, id, date);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }

        public IEnumerable<T> GetDocuments<T>(string function, int id)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<DocumentDto>(function, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
