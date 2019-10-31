namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomSfCatBloomberg
    {
        [Display(Name = "Fixed Income")]
        FixedIncome = 1,

        [Display(Name = "Mixed Allocation")]
        MixedAllocation = 2,

        [Display(Name = "Specialty")]
        Specialty = 3,

        [Display(Name = "Real Estate")]
        RealEstate = 4,

        [Display(Name = "Commodity")]
        Commodity = 5,

        [Display(Name = "Money Market")]
        MoneyMarket = 6,

        [Display(Name = "Alternative")]
        Alternative = 7
    }
}
