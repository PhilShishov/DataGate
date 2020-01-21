using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
{
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
