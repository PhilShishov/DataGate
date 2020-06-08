namespace DataGate.Services.Data.Storage
{
    using System.Collections.Generic;

    using DataGate.Data.Common.Repositories;
    using DataGate.Services.Data.Storage.Contracts;

    public class SubFundSelectListService : ISubFundSelectListService
    {
        private readonly ISubFundRepository repository;

        public SubFundSelectListService(
            ISubFundRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<string> GetAllTbDomCalculationDate()
               => this.repository.AllTbDomCalculationDate();

        public IReadOnlyCollection<string> GetAllTbDomCesrClass()
         => this.repository.AllTbDomCesrClass();

        public IReadOnlyCollection<string> GetAllTbDomCurrencyCode()
         => this.repository.AllTbDomCurrencyCode();

        public IReadOnlyCollection<string> GetAllTbDomDerivMarket()
         => this.repository.AllTbDomDerivMarket();

        public IReadOnlyCollection<string> GetAllTbDomDerivPurpose()
         => this.repository.AllTbDomDerivPurpose();

        public IReadOnlyCollection<string> GetAllTbDomFrequency()
         => this.repository.AllTbDomFrequency();

        public IReadOnlyCollection<string> GetAllTbDomGeographicalFocus()
         => this.repository.AllTbDomGeographicalFocus();

        public IReadOnlyCollection<string> GetAllTbDomGlobalExposure()
         => this.repository.AllTbDomGlobalExposure();

        public IReadOnlyCollection<string> GetAllTbDomPrincipalAssetClass()
         => this.repository.AllTbDomPrincipalAssetClass();

        public IReadOnlyCollection<string> GetAllTbDomPrincipalInvestmentStrategy()
         => this.repository.AllTbDomPrincipalInvestmentStrategy();

        public IReadOnlyCollection<string> GetAllTbDomSfCatBloomberg()
         => this.repository.AllTbDomSfCatBloomberg();

        public IReadOnlyCollection<string> GetAllTbDomSfCatMorningStar()
         => this.repository.AllTbDomSfCatMorningStar();

        public IReadOnlyCollection<string> GetAllTbDomSfCatSix()
         => this.repository.AllTbDomSfCatSix();

        public IReadOnlyCollection<string> GetAllTbDomSFStatus()
         => this.repository.AllTbDomSFStatus();

        public IReadOnlyCollection<string> GetAllTbDomTypeOfMarket()
         => this.repository.AllTbDomTypeOfMarket();

        public IReadOnlyCollection<string> GetAllTbDomValuationDate()
         => this.repository.AllTbDomValuationDate();
    }
}
