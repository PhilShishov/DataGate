// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Repositories.AppContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Data.Common.Repositories.AppContext;

    public class SubFundRepository : ISubFundRepository
    {
        public SubFundRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected ApplicationDbContext Context { get; set; }

        public ISet<string> GetAllContainers()
        => this.Context.TbHistoryFund.Select(f => f.FOfficialFundName).ToHashSet();

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

        public async Task<int?> ByIdCB(string sfCatBloomberg)
        => await this.Context.TbDomSfCatBloomberg
            .Where(x => x.CatBloombergDesc == sfCatBloomberg)
            .Select(x => x.CatBloombergId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdCC(string cesrClass)
        => await this.Context.TbDomCesrClass
            .Where(x => x.CDesc == cesrClass)
            .Select(x => x.CcId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdCD(string calculationDate)
        => await this.Context.TbDomCalculationDate
            .Where(x => x.CdDesc == calculationDate)
            .Select(x => x.CdId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdCM(string sfCatMorningStar)
        => await this.Context.TbDomSfCatMorningstar
            .Where(x => x.CMorningstarDesc == sfCatMorningStar)
            .Select(x => x.CMorningstarId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdCS(string sfCatSix)
        => await this.Context.TbDomSfCatSix
            .Where(x => x.CatSixDesc == sfCatSix)
            .Select(x => x.CatSixId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdDM(string derivMarket)
        => await this.Context.TbDomDerivMarket
            .Where(x => x.DmDesc == derivMarket)
            .Select(x => x.DmId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdDP(string derivPurpose)
        => await this.Context.TbDomDerivPurpose
            .Where(x => x.DpDesc == derivPurpose)
            .Select(x => x.DpId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdGE(string globalExposure)
        => await this.Context.TbDomGlobalExposure
            .Where(x => x.GeDesc == globalExposure)
            .Select(x => x.GeId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdGF(string geographicalFocus)
        => await this.Context.TbDomCssfGeographicalFocus
            .Where(x => x.GfDesc == geographicalFocus)
            .Select(x => x.GfId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdNF(string navFrequency)
        => await this.Context.TbDomNavFrequency
            .Where(x => x.NfDesc == navFrequency)
            .Select(x => x.NfId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdPAC(string principalAssetClass)
        => await this.Context.TbDomCssfPrincipalAssetClass
            .Where(x => x.PacDesc == principalAssetClass)
            .Select(x => x.PacId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdPIS(string principalInvestmentStrategy)
        => await this.Context.TbDomPrincipalInvestmentStrategy
            .Where(x => x.PisDesc == principalInvestmentStrategy)
            .Select(x => x.PisId)
            .FirstOrDefaultAsync();

        public async Task<int> ByIdST(string status)
        => await this.Context.TbDomSfStatus
            .Where(x => x.StDesc == status)
            .Select(x => x.StId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdTM(string typeOfMarket)
        => await this.Context.TbDomTypeOfMarket
            .Where(x => x.TomDesc == typeOfMarket)
            .Select(x => x.TomId)
            .FirstOrDefaultAsync();

        public async Task<int?> ByIdVD(string valuationDate)
        => await this.Context.TbDomValutationDate
            .Where(x => x.VdDesc == valuationDate)
            .Select(x => x.VdId)
            .FirstOrDefaultAsync();

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