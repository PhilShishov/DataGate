namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Collections.Generic;

    public interface ISubFundSelectListService
    {
        IReadOnlyCollection<string> GetAllTbDomCalculationDate();

        IReadOnlyCollection<string> GetAllTbDomCesrClass();

        IReadOnlyCollection<string> GetAllTbDomCurrencyCode();

        IReadOnlyCollection<string> GetAllTbDomDerivMarket();

        IReadOnlyCollection<string> GetAllTbDomDerivPurpose();

        IReadOnlyCollection<string> GetAllTbDomFrequency();

        IReadOnlyCollection<string> GetAllTbDomGeographicalFocus();

        IReadOnlyCollection<string> GetAllTbDomGlobalExposure();

        IReadOnlyCollection<string> GetAllTbDomPrincipalAssetClass();

        IReadOnlyCollection<string> GetAllTbDomPrincipalInvestmentStrategy();

        IReadOnlyCollection<string> GetAllTbDomSfCatBloomberg();

        IReadOnlyCollection<string> GetAllTbDomSfCatMorningStar();

        IReadOnlyCollection<string> GetAllTbDomSfCatSix();

        IReadOnlyCollection<string> GetAllTbDomSFStatus();

        IReadOnlyCollection<string> GetAllTbDomTypeOfMarket();

        IReadOnlyCollection<string> GetAllTbDomValuationDate();
    }
}
