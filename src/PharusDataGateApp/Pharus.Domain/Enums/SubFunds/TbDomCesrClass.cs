namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomCesrClass
    {
        [Display(Name = " Market Fund")]
        MarketFund = 1,

        [Display(Name = "Absolute Return")]
        AbsoluteReturn = 2,

        [Display(Name = "Total Return")]
        TotalReturn = 3,

        [Display(Name = "Lyfe Cycle Fund")]
        LyfeCycleFund = 4,

        [Display(Name = "Structured Fund")]
        StructuredFund = 5
    }
}
