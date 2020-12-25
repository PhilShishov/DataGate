// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.CountriesDist
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class CountryDistService : ICountryDistService
    {
        private readonly ISqlQueryManager sqlManager;

        public CountryDistService(ISqlQueryManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        public IEnumerable<T> All<T>(string function, int id)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<CountryDistDto>(function, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
