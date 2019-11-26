namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomTypeOfMarket
    {
        public TbDomTypeOfMarket()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int TomId { get; set; }

        public string TomDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
