﻿namespace DataGate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubFundRepository : IDisposable
    {
        ISet<string> GetAllContainers();
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
