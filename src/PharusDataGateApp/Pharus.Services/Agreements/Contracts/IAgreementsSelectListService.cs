namespace Pharus.Services.Agreements.Contracts
{
    using System.Collections.Generic;

    public interface IAgreementsSelectListService
    {
        List<string> GetAllTbDomAgreementStatus();

        List<string> GetAllTbCompanies();
    }
}