namespace Pharus.Services.SubFunds
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;

    public class SubFundsSelectListService : ISubFundsSelectListService
    {
        private readonly PharusProdContext _context;

        public SubFundsSelectListService(
            PharusProdContext context)
        {
            this._context = context;
        }
        public List<string> GetAllTbDomCalculationDate()
        {
            var calculationDate = this._context.TbDomCalculationDate.Select(tb => tb.CdDesc).ToList();

            return calculationDate;
        }

        public List<string> GetAllTbDomCesrClass()
        {
            var cesrClass = this._context.TbDomCesrClass.Select(tb => tb.CDesc).ToList();

            return cesrClass;
        }

        public List<string> GetAllTbDomCurrencyCode()
        {
            var currencyCode = this._context.TbDomIsoCurrency.Select(tb => tb.IsoCcyCode).ToList();

            return currencyCode;
        }

        public List<string> GetAllTbDomDerivMarket()
        {
            var derivMarket = this._context.TbDomDerivMarket.Select(tb => tb.DmDesc).ToList();

            return derivMarket;
        }

        public List<string> GetAllTbDomDerivPurpose()
        {
            var derivPurpose = this._context.TbDomDerivPurpose.Select(tb => tb.DpDesc).ToList();

            return derivPurpose;
        }

        public List<string> GetAllTbDomFrequency()
        {
            var frequency = this._context.TbDomNavFrequency.Select(tb => tb.NfDesc).ToList();

            return frequency;
        }

        public List<string> GetAllTbDomGeographicalFocus()
        {
            var geoFocus = this._context.TbDomCssfGeographicalFocus.Select(tb => tb.GfDesc).ToList();

            return geoFocus;
        }

        public List<string> GetAllTbDomGlobalExposure()
        {
            var globalExposure = this._context.TbDomGlobalExposure.Select(tb => tb.GeDesc).ToList();

            return globalExposure;
        }

        public List<string> GetAllTbDomPrincipalAssetClass()
        {
            var principalAssetClass = this._context.TbDomCssfPrincipalAssetClass.Select(tb => tb.PacDesc).ToList();

            return principalAssetClass;
        }

        public List<string> GetAllTbDomPrincipalInvestmentStrategy()
        {
            var investmentStrategy = this._context.TbDomPrincipalInvestmentStrategy.Select(tb => tb.PisDesc).ToList();

            return investmentStrategy;
        }

        public List<string> GetAllTbDomSfCatBloomberg()
        {
            var catBloomberg = this._context.TbDomSfCatBloomberg.Select(tb => tb.CatBloombergDesc).ToList();

            return catBloomberg;
        }

        public List<string> GetAllTbDomSfCatMorningStar()
        {
            var catMorningStar = this._context.TbDomSfCatMorningstar.Select(tb => tb.CMorningstarDesc).ToList();

            return catMorningStar;
        }

        public List<string> GetAllTbDomSfCatSix()
        {
            var catSix = this._context.TbDomSfCatSix.Select(tb => tb.CatSixDesc).ToList();

            return catSix;
        }

        public List<string> GetAllTbDomSFStatus()
        {
            var sfStatus = this._context.TbDomSfStatus.Select(tb => tb.StDesc).ToList();

            return sfStatus;
        }

        public List<string> GetAllTbDomTypeOfMarket()
        {
            var typeOfMarket = this._context.TbDomTypeOfMarket.Select(tb => tb.TomDesc).ToList();

            return typeOfMarket;
        }

        public List<string> GetAllTbDomValuationDate()
        {
            var valuationDate = this._context.TbDomValutationDate.Select(tb => tb.VdDesc).ToList();

            return valuationDate;
        }
    }
}