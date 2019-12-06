// Service class for managing subfunds selects

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.SubFunds
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.SubFunds.Contracts;

    public class SubFundsSelectListService : ISubFundsSelectListService
    {
        private readonly Pharus_vFinale_Context context;

        public SubFundsSelectListService(
            Pharus_vFinale_Context context)
        {
            this.context = context;
        }

        public List<string> GetAllTbDomCalculationDate()
        {
            var calculationDate = this.context.TbDomCalculationDate
                .Select(tb => tb.CdDesc)
                .ToList();

            return calculationDate;
        }

        public List<string> GetAllTbDomCesrClass()
        {
            var cesrClass = this.context.TbDomCesrClass
                .Select(tb => tb.CDesc)
                .ToList();

            return cesrClass;
        }

        public List<string> GetAllTbDomCurrencyCode()
        {
            var currencyCode = this.context.TbDomIsoCurrency
                .Select(tb => tb.IsoCcyCode)
                .ToList();

            return currencyCode;
        }

        public List<string> GetAllTbDomDerivMarket()
        {
            var derivMarket = this.context.TbDomDerivMarket
                .Select(tb => tb.DmDesc)
                .ToList();

            return derivMarket;
        }

        public List<string> GetAllTbDomDerivPurpose()
        {
            var derivPurpose = this.context.TbDomDerivPurpose
                .Select(tb => tb.DpDesc)
                .ToList();

            return derivPurpose;
        }

        public List<string> GetAllTbDomFrequency()
        {
            var frequency = this.context.TbDomNavFrequency
                .Select(tb => tb.NfDesc)
                .ToList();

            return frequency;
        }

        public List<string> GetAllTbDomGeographicalFocus()
        {
            var geoFocus = this.context.TbDomCssfGeographicalFocus
                .Select(tb => tb.GfDesc)
                .ToList();

            return geoFocus;
        }

        public List<string> GetAllTbDomGlobalExposure()
        {
            var globalExposure = this.context.TbDomGlobalExposure
                .Select(tb => tb.GeDesc)
                .ToList();

            return globalExposure;
        }

        public List<string> GetAllTbDomPrincipalAssetClass()
        {
            var principalAssetClass = this.context.TbDomCssfPrincipalAssetClass
                .Select(tb => tb.PacDesc)
                .ToList();

            return principalAssetClass;
        }

        public List<string> GetAllTbDomPrincipalInvestmentStrategy()
        {
            var investmentStrategy = this.context.TbDomPrincipalInvestmentStrategy
                .Select(tb => tb.PisDesc)
                .ToList();

            return investmentStrategy;
        }

        public List<string> GetAllTbDomSfCatBloomberg()
        {
            var catBloomberg = this.context.TbDomSfCatBloomberg
                .Select(tb => tb.CatBloombergDesc)
                .ToList();

            return catBloomberg;
        }

        public List<string> GetAllTbDomSfCatMorningStar()
        {
            var catMorningStar = this.context.TbDomSfCatMorningstar
                .Select(tb => tb.CMorningstarDesc)
                .ToList();

            return catMorningStar;
        }

        public List<string> GetAllTbDomSfCatSix()
        {
            var catSix = this.context.TbDomSfCatSix
                .Select(tb => tb.CatSixDesc)
                .ToList();

            return catSix;
        }

        public List<string> GetAllTbDomSFStatus()
        {
            var sfStatus = this.context.TbDomSfStatus
                .Select(tb => tb.StDesc)
                .ToList();

            return sfStatus;
        }

        public List<string> GetAllTbDomTypeOfMarket()
        {
            var typeOfMarket = this.context.TbDomTypeOfMarket
                .Select(tb => tb.TomDesc)
                .ToList();

            return typeOfMarket;
        }

        public List<string> GetAllTbDomValuationDate()
        {
            var valuationDate = this.context.TbDomValutationDate
                .Select(tb => tb.VdDesc)
                .ToList();

            return valuationDate;
        }
    }
}