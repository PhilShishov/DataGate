namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShareClassRepository : IDisposable
    {
        ISet<string> AllContainers();
        IReadOnlyCollection<string> AllTbDomShareStatus();
        IReadOnlyCollection<string> AllTbDomInvestorType();
        IReadOnlyCollection<string> AllTbDomShareType();
        IReadOnlyCollection<string> AllTbDomCurrencyCode();
        IReadOnlyCollection<string> AllTbDomCountry();
        Task<string> ByNameCountry(string countryToFormat);
        Task<int?> ByIdInvestorType(string investorType);
        Task<int?> ByIdShareType(string shareType);
        Task<int> ByIdStatus(string status);
    }
}
