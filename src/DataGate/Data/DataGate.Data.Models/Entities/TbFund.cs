namespace DataGate.Data.Models.Entities
{
    using System.Collections.Generic;

    public partial class TbFund
    {
        public TbFund()
        {
            this.TbFundSubFund = new HashSet<TbFundSubFund>();
            this.TbHistoryFund = new HashSet<TbHistoryFund>();
            this.TbMapFilefund = new HashSet<TbMapFilefund>();
            this.TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
        }

        public int FId { get; set; }

        public virtual ICollection<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
        public virtual ICollection<TbMapFilefund> TbMapFilefund { get; set; }
        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
    }
}
