namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomFStatus
    {
        public TbDomFStatus()
        {
            TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int StFId { get; set; }
        public string StFDesc { get; set; }

        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}
