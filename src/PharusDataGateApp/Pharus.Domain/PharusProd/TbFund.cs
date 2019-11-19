using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbFund
    {
        public TbFund()
        {
            TbFundSubFund = new HashSet<TbFundSubFund>();
            TbHistoryFund = new HashSet<TbHistoryFund>();
            TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
        }

        public int FId { get; set; }

        public virtual ICollection<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
    }
}
