using System;
using System.Collections.Generic;

namespace Pharus.Domain.Pharus_vFinale
{
    public partial class TbDomCalculationDate
    {
        public TbDomCalculationDate()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CdId { get; set; }
        public string CdDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
