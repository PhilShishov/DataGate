using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
{
    public partial class TbDomGlobalExposure
    {
        public TbDomGlobalExposure()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int GeId { get; set; }
        public string GeDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
