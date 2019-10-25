using Pharus.Domain.Attributes;

namespace Pharus.Domain.Enums
{
    public enum TbDomFStatus
    {
        [StringValue("Active")]
        Active = 1,
        [StringValue("Inactive - Liquidated")]
        InactiveLiquidated = 2,
        [StringValue("Inactive - Closed")]
        InactiveClosed = 3,
        [StringValue("Inactive - To Be Launched")]
        InactiveToBeLaunched = 4,
        [StringValue("Inactive - Merged")]
        InactiveMerged = 5
    }
}
