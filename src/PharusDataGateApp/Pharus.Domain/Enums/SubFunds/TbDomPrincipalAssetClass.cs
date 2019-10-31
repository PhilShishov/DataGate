namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomPrincipalAssetClass
    {
        [Display(Name = "Equity")]
        Equity = 1,

        [Display(Name = "IG Bond")]
        IGBond = 2,

        [Display(Name = "HY Bond")]
        HYBond = 3,

        [Display(Name = "General Bond")]
        GeneralBond = 4,

        [Display(Name = "Convertible Bond")]
        ConvertibleBond = 5,

        [Display(Name = "MM instruments")]
        MMinstruments = 6,

        [Display(Name = "ABS/MBS")]
        ABSMBS = 7,

        [Display(Name = "Foreign Exchange")]
        ForeignExchange = 8,

        [Display(Name = "Commodities")]
        Commodities = 9,

        [Display(Name = "Volatility")]
        Volatility = 10,

        [Display(Name = "Mixed Equity Bond")]
        MixedEquityBond = 11,

        [Display(Name = "Mixed Others")]
        MixedOthers = 12,

        [Display(Name = "Others")]
        Others = 13
    }
}
