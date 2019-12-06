namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System;

    using Pharus.Domain.Models.Pharus_vFinale;

    public partial class TbFundSubFund
    {
        public int SfId { get; set; }
        public int FId { get; set; }
        public DateTime FsfStartConnection { get; set; }
        public DateTime? FsfEndConnection { get; set; }

        public virtual TbFund F { get; set; }
        public virtual TbSubFund Sf { get; set; }
    }
}
