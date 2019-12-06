using System;
using System.Collections.Generic;

namespace Pharus.App.Models
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
