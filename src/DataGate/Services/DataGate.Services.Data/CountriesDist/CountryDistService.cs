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

        public IEnumerable<T> GetCountries<T>(string function, int id)
        {
            var dto = this.sqlManager.ExecuteQueryMapping<CountryDistDto>(function, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
