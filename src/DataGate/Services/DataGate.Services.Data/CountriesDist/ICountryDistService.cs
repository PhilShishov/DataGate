namespace DataGate.Services.Data.CountriesDist
{
    using System.Collections.Generic;

    public interface ICountryDistService
    {
        IEnumerable<TDestination> GetCountries<TDestination>(string function, int id);
    }
}
