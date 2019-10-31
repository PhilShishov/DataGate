namespace Pharus.Domain.Enums.ShareClasses
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomShareStatus
    {
        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Inactive - Liquidated")]
        InactiveLiquidated = 2,

        [Display(Name = "Inactive - Closed")]
        InactiveClosed = 3,

        [Display(Name = "Inactive - To Be Launched")]
        InactiveToBeLaunched = 4,

        [Display(Name = "Inactive - Merged")]
        InactiveMerged = 5
    }
}