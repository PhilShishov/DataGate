using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbSubFund
    {
        public TbSubFund()
        {
            TbFundSubFund = new HashSet<TbFundSubFund>();
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
            TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
            TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
        }

        public int IdSubFund { get; set; }

        public virtual ICollection<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
    }
}
