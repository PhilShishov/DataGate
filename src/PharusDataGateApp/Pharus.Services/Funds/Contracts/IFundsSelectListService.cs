namespace Pharus.Services.Funds.Contracts
{
    using System.Collections.Generic;

    public interface IFundsSelectListService
    {
        List<string> GetAllTbDomCompanyAcronym();

        List<string> GetAllTbDomCompanyDesc();

        List<string> GetAllTbDomFStatus();

        List<string> GetAllTbDomLegalForm();

        List<string> GetAllTbDomLegalType();

        List<string> GetAllTbDomLegalVehicle();
    }
}