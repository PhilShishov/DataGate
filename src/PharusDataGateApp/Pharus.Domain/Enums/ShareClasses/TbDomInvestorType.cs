namespace Pharus.Domain.Enums.ShareClasses
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomInvestorType
    {
        Retail = 1,
        Qualified = 2,
        Professional = 3,
        Institutional = 4,

        [Display(Name = "Well Informed")]
        WellInformed = 5,
    }
}