namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomPrincipalInvestmentStrategy
    {
        Long = 1,
        Short = 2,

        [Display(Name = "Long Short")]
        LongShort = 3,

        [Display(Name = "MarketNeutral")]
        MarketNeutral = 4,

        Arbitrage = 5,

        [Display(Name = "Unconstrained/Multistrategy")]
        UnconstrainedMultistrategy = 6
    }
}
