namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShareClassRepository : IDisposable
    {
        ISet<string> GetAllContainers();
        IReadOnlyCollection<string> GetAllTbDomShareStatus();
        IReadOnlyCollection<string> GetAllTbDomInvestorType();
        IReadOnlyCollection<string> GetAllTbDomShareType();
        IReadOnlyCollection<string> GetAllTbDomCurrencyCode();
        IReadOnlyCollection<string> GetAllTbDomCountry();
        Task<string> ByNameCountry(string countryToFormat);
        Task<int?> ByIdInvestorType(string investorType);
        Task<int?> ByIdShareType(string shareType);
        Task<int> ByIdStatus(string status);
    }
}
