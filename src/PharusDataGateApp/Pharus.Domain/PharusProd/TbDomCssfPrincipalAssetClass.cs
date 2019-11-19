using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomCssfPrincipalAssetClass
    {
        public TbDomCssfPrincipalAssetClass()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int PacId { get; set; }
        public string PacDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
