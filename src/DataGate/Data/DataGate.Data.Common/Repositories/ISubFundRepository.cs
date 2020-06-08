namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface ISubFundRepository : IDisposable
    {
        IReadOnlyCollection<string> AllTbDomCalculationDate();
        IReadOnlyCollection<string> AllTbDomCesrClass();
        IReadOnlyCollection<string> AllTbDomCurrencyCode();
        IReadOnlyCollection<string> AllTbDomDerivMarket();
        IReadOnlyCollection<string> AllTbDomDerivPurpose();
        IReadOnlyCollection<string> AllTbDomFrequency();
        IReadOnlyCollection<string> AllTbDomGeographicalFocus();
        IReadOnlyCollection<string> AllTbDomGlobalExposure();
        IReadOnlyCollection<string> AllTbDomPrincipalAssetClass();
        IReadOnlyCollection<string> AllTbDomPrincipalInvestmentStrategy();
        IReadOnlyCollection<string> AllTbDomSfCatBloomberg();
        IReadOnlyCollection<string> AllTbDomSfCatMorningStar();
        IReadOnlyCollection<string> AllTbDomSfCatSix();
        IReadOnlyCollection<string> AllTbDomSFStatus();
        IReadOnlyCollection<string> AllTbDomTypeOfMarket();
        IReadOnlyCollection<string> AllTbDomValuationDate();
    }
}
