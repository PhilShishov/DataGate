using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
{
    public partial class TbDomSfCatBloomberg
    {
        public TbDomSfCatBloomberg()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CatBloombergId { get; set; }
        public string CatBloombergDesc { get; set; }
        public string CatBloombergDescExpl { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
