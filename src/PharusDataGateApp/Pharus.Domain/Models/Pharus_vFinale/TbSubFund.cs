using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
    public partial class TbSubFund
    {
        public TbSubFund()
        {
            TbFundSubFund = new HashSet<TbFundSubFund>();
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
            TbMapFilesubfund = new HashSet<TbMapFilesubfund>();
            TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
            TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
        }

        public int IdSubFund { get; set; }

        public virtual ICollection<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbMapFilesubfund> TbMapFilesubfund { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
    }
}
