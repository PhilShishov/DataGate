using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
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
