namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomSfCatSix
    {
        [Display(Name = "Equities Fund/Equity unit trust")]
        EquitiesFundEquityUnitTrust = 1,

        [Display(Name = "Fixed interest sec. Fund/ bond Fund")]
        FixedInterestSecFundbondFund = 2,

        [Display(Name = "Money market / Currency Fund")]
        MoneyMarketCurrencyFund = 3,

        [Display(Name = "Convertible bond Fund")]
        ConvertibleBondFund = 4,

        [Display(Name = "Invest. objective Fund/Balanced Fund")]
        InvestObjectiveFundBalancedFund = 5,

        [Display(Name = "Hedge Fund")]
        HedgeFund = 6,

        [Display(Name = "Real estate investment Fund")]
        RealEstateInvestmentFund = 7,

        [Display(Name = "Industry Fund")]
        IndustryFund = 8,

        [Display(Name = "Index Fund")]
        IndexFund = 9,

        [Display(Name = "Fund of Funds")]
        FundOfFunds = 10,

        [Display(Name = "Country / Regional Fund")]
        CountryRegionalFund = 11,

        [Display(Name = "Allroundfunds/Mixed Funds")]
        AllroundfundsMixedFunds = 12,

        [Display(Name = "Equities & industry Fund")]
        EquitiesindustryFund = 13,

        [Display(Name = "Equities & country/regional Fund")]
        EquitiescountryregionalFund = 14,

        [Display(Name = "Bond & industry Funds")]
        BondindustryFunds = 15,

        [Display(Name = "Bond & country/regional Funds")]
        BondcountryregionalFunds = 16,

        [Display(Name = "Guarantee fund/insurance Fund")]
        GuaranteefundinsuranceFund = 17,

        [Display(Name = "Pension Fund")]
        PensionFund = 18,

        [Display(Name = "Equity/Bond Fund")]
        EquityBondFund = 19,

        [Display(Name = "Sector-/Country-& Regional Fund")]
        SectorCountryRegionalFund = 20,

        [Display(Name = "Equity/Sector-/Country-& Regional Fund")]
        EquitySectorCountryRegionalFund = 21,

        [Display(Name = "Bond/Sector-/Country-& Regional Fund")]
        BondSectorCountryRegionalFund = 22,

        [Display(Name = "Investment foundation claim")]
        Investmentfoundationclaim = 23,

        [Display(Name = "Insurance Funds")]
        InsuranceFunds = 24,

        [Display(Name = "Bond & Equity/Country-& Regional Fund")]
        BondEquityCountryRegionalFund = 25,

        [Display(Name = "Mortgage Fund")]
        MortgageFund = 26,

        [Display(Name = "Futures/Options Funds")]
        FuturesOptionsFunds = 27,

        [Display(Name = "Derivative Fund")]
        DerivativeFund = 28,

        [Display(Name = "ETF")]
        ETF = 29,

        [Display(Name = "Private Equity Fund")]
        PrivateEquityFund = 30,

        [Display(Name = "Commodity Fund")]
        CommodityFund = 31,

        [Display(Name = "Fund of Hedge Funds")]
        FundofHedgeFunds = 32,

        [Display(Name = "Fund of Private Equity Funds")]
        FundofPrivateEquityFunds = 33,

        [Display(Name = "Alternative Fund")]
        AlternativeFund = 34,

        [Display(Name = "Other")]
        Other = 35
    }
}
