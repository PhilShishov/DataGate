namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomCalculationDate
    {
        public TbDomCalculationDate()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CdId { get; set; }
        public string CdDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
