namespace Pharus.Services.Contracts
{
    using System.Collections.Generic;

    public interface IShareClassesSelectListService
    {
        List<string> GetAllTbDomInvestorType();
        List<string> GetAllTbDomCurrencyCode();
        List<string> GetAllTbDomShareStatus();
        List<string> GetAllTbDomShareType();
    }
}
