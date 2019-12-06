namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

    using Pharus.Domain.Models.Pharus_vFinale;

    public partial class TbDomDerivMarket
    {
        public TbDomDerivMarket()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int DmId { get; set; }

        public string DmDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}