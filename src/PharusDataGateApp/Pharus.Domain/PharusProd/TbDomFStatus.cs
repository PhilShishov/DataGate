using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomFStatus
    {
        public TbDomFStatus()
        {
            TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int StFId { get; set; }
        public string StFDesc { get; set; }

        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}
