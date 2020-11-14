namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbHistorySubFund
    {
        public int SfId { get; set; }
        public DateTime SfInitialDate { get; set; }
        public DateTime? SfEndDate { get; set; }
        public string SfOfficialSubFundName { get; set; }
        public string SfShortSubFundName { get; set; }
        public string SfCssfCode { get; set; }
        public string SfFaCode { get; set; }
        public string SfDepCode { get; set; }
        public string SfTaCode { get; set; }
        public DateTime? SfFirstNavDate { get; set; }
        public DateTime? SfLastNavDate { get; set; }
        public DateTime? SfCssfAuthDate { get; set; }
        public DateTime? SfExpDate { get; set; }
        public int? SfStatus { get; set; }
        public string SfLeiCode { get; set; }
        public int? SfCesrClass { get; set; }
        public int? SfCssfGeographicalFocus { get; set; }
        public int? SfGlobalExposure { get; set; }
        public string SfCurrency { get; set; }
        public int? SfNavFrequency { get; set; }
        public int? SfValutationDate { get; set; }
        public int? SfCalculationDate { get; set; }
        public bool? SfDerivatives { get; set; }
        public int? SfDerivMarket { get; set; }
        public int? SfDerivPurpose { get; set; }
        public DateTime? SfLastProspectus { get; set; }
        public DateTime? SfLastProspectusDate { get; set; }
        public int? SfPrincipalAssetClass { get; set; }
        public int? SfTypeOfMarket { get; set; }
        public int? SfPrincipalInvestmentStrategy { get; set; }
        public string SfClearingCode { get; set; }
        public int? SfCatMorningstar { get; set; }
        public int? SfCategorySix { get; set; }
        public int? SfCategoryBloomberg { get; set; }
        public string SfChangeComment { get; set; }
        public string SfCommentTitle { get; set; }

        public virtual TbSubFund Sf { get; set; }
        public virtual TbDomCalculationDate SfCalculationDateNavigation { get; set; }
        public virtual TbDomSfCatMorningstar SfCatMorningstarNavigation { get; set; }
        public virtual TbDomSfCatBloomberg SfCategoryBloombergNavigation { get; set; }
        public virtual TbDomSfCatSix SfCategorySixNavigation { get; set; }
        public virtual TbDomCesrClass SfCesrClassNavigation { get; set; }
        public virtual TbDomCssfGeographicalFocus SfCssfGeographicalFocusNavigation { get; set; }
        public virtual TbDomIsoCurrency SfCurrencyNavigation { get; set; }
        public virtual TbDomDerivMarket SfDerivMarketNavigation { get; set; }
        public virtual TbDomDerivPurpose SfDerivPurposeNavigation { get; set; }
        public virtual TbDomGlobalExposure SfGlobalExposureNavigation { get; set; }
        public virtual TbDomNavFrequency SfNavFrequencyNavigation { get; set; }
        public virtual TbDomCssfPrincipalAssetClass SfPrincipalAssetClassNavigation { get; set; }
        public virtual TbDomPrincipalInvestmentStrategy SfPrincipalInvestmentStrategyNavigation { get; set; }
        public virtual TbDomSfStatus SfStatusNavigation { get; set; }
        public virtual TbDomTypeOfMarket SfTypeOfMarketNavigation { get; set; }
        public virtual TbDomValutationDate SfValutationDateNavigation { get; set; }
    }
}
