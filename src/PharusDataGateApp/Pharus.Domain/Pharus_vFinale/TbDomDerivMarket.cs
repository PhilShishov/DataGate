namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomDerivMarket
    {
        public TbDomDerivMarket()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int DmId { get; set; }

        public string DmDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
