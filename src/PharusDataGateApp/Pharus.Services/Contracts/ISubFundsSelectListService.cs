namespace Pharus.Services.Contracts
{
    using System.Collections.Generic;

    public interface ISubFundsSelectListService
    {
        List<string> GetAllTbDomCalculationDate();
        List<string> GetAllTbDomCesrClass();
        List<string> GetAllTbDomCurrencyCode();
        List<string> GetAllTbDomDerivMarket();
        List<string> GetAllTbDomDerivPurpose();
        List<string> GetAllTbDomFrequency();
        List<string> GetAllTbDomGeographicalFocus();
        List<string> GetAllTbDomGlobalExposure();
        List<string> GetAllTbDomPrincipalAssetClass();
        List<string> GetAllTbDomPrincipalInvestmentStrategy();
        List<string> GetAllTbDomSfCatBloomberg();
        List<string> GetAllTbDomSfCatMorningStar();
        List<string> GetAllTbDomSfCatSix();
        List<string> GetAllTbDomSFStatus();
        List<string> GetAllTbDomTypeOfMarket();
        List<string> GetAllTbDomValuationDate();
    }
}
