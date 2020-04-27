using System;
using System.Collections.Generic;

namespace DataGate.Data.Models.Entities
{
    public partial class TbSubFund
    {
        public TbSubFund()
        {
            this.TbFundSubFund = new HashSet<TbFundSubFund>();
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
            this.TbMapFilesubfund = new HashSet<TbMapFilesubfund>();
            this.TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
            this.TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
        }

        public int IdSubFund { get; set; }

        public virtual ICollection<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbMapFilesubfund> TbMapFilesubfund { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
    }
}
