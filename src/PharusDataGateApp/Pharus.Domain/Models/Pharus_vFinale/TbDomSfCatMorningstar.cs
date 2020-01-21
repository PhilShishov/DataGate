using System;
using System.Collections.Generic;

namespace Pharus.Domain.Models.Pharus_vFinale
{
    public partial class TbDomSfCatMorningstar
    {
        public TbDomSfCatMorningstar()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CMorningstarId { get; set; }
        public string CMorningstarDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
