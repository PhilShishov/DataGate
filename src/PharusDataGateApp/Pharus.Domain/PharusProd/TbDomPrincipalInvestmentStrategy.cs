using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomPrincipalInvestmentStrategy
    {
        public TbDomPrincipalInvestmentStrategy()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int PisId { get; set; }
        public string PisDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
