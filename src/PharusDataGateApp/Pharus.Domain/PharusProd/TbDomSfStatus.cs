using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomSfStatus
    {
        public TbDomSfStatus()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int StId { get; set; }
        public string StDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
