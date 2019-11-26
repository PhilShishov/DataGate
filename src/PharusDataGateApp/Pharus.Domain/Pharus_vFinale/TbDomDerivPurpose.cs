namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomDerivPurpose
    {
        public TbDomDerivPurpose()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int DpId { get; set; }

        public string DpDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
