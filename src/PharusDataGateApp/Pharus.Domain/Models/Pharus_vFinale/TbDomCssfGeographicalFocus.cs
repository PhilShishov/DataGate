using System;
using System.Collections.Generic;

namespace Pharus.Domain.Models.Pharus_vFinale
{
    public partial class TbDomCssfGeographicalFocus
    {
        public TbDomCssfGeographicalFocus()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int GfId { get; set; }
        public string GfDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
