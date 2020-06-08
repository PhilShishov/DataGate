namespace DataGate.Data.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Data.Common.Repositories;

    public class SubFundRepository : ISubFundRepository
    {
        public SubFundRepository(Pharus_vFinaleDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected Pharus_vFinaleDbContext Context { get; set; }

        public IReadOnlyCollection<string> AllTbDomCalculationDate()
            => this.Context.TbDomCalculationDate.Select(x => x.CdDesc).ToList();
        public IReadOnlyCollection<string> AllTbDomCesrClass()
            => this.Context.TbDomCesrClass.Select(x => x.CDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomCurrencyCode()
            => this.Context.TbDomIsoCurrency.Select(x => x.IsoCcyCode).ToList();

        public IReadOnlyCollection<string> AllTbDomDerivMarket()
            => this.Context.TbDomDerivMarket.Select(x => x.DmDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomDerivPurpose()
            => this.Context.TbDomDerivPurpose.Select(x => x.DpDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomFrequency()
            => this.Context.TbDomNavFrequency.Select(x => x.NfDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomGeographicalFocus()
            => this.Context.TbDomCssfGeographicalFocus.Select(x => x.GfDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomGlobalExposure()
            => this.Context.TbDomGlobalExposure.Select(x => x.GeDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomPrincipalAssetClass()
            => this.Context.TbDomCssfPrincipalAssetClass.Select(x => x.PacDesc).ToList();        

        public IReadOnlyCollection<string> AllTbDomPrincipalInvestmentStrategy()
            => this.Context.TbDomPrincipalInvestmentStrategy.Select(x => x.PisDesc).ToList();        

        public IReadOnlyCollection<string> AllTbDomSfCatBloomberg()
            => this.Context.TbDomSfCatBloomberg.Select(x => x.CatBloombergDesc).ToList();        

        public IReadOnlyCollection<string> AllTbDomSfCatMorningStar()
            => this.Context.TbDomSfCatMorningstar.Select(x => x.CMorningstarDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomSfCatSix()
            => this.Context.TbDomSfCatSix.Select(x => x.CatSixDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomSFStatus()
            => this.Context.TbDomSfStatus.Select(x => x.StDesc).ToList();
    
        public IReadOnlyCollection<string> AllTbDomTypeOfMarket()
            => this.Context.TbDomTypeOfMarket.Select(x => x.TomDesc).ToList();

        public IReadOnlyCollection<string> AllTbDomValuationDate()
            => this.Context.TbDomValutationDate.Select(x => x.VdDesc).ToList();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}