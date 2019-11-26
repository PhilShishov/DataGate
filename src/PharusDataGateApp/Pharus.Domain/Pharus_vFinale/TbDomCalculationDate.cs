namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomCalculationDate
    {
        public TbDomCalculationDate()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CdId { get; set; }

        public string CdDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
