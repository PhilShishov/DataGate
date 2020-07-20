namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubFundRepository : IDisposable
    {
        ISet<string> GetAllContainers();
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
        Task<int?> ByIdCC(string cesrClass);
        Task<int> ByIdST(string status);
        Task<int?> ByIdGF(string geographicalFocus);
        Task<int?> ByIdGE(string globalExposure);
        Task<int?> ByIdNF(string navFrequency);
        Task<int?> ByIdVD(string valuationDate);
        Task<int?> ByIdCD(string calculationDate);
        Task<int?> ByIdDM(string derivMarket);
        Task<int?> ByIdDP(string derivPurpose);
        Task<int?> ByIdPAC(string principalAssetClass);
        Task<int?> ByIdTM(string typeOfMarket);
        Task<int?> ByIdPIS(string principalInvestmentStrategy);
        Task<int?> ByIdCM(string sfCatMorningStar);
        Task<int?> ByIdCS(string sfCatSix);
        Task<int?> ByIdCB(string sfCatBloomberg);
    }
}
