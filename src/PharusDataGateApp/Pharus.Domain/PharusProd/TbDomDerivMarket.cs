using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
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
