namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomTypeOfMarket
    {
        public TbDomTypeOfMarket()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int TomId { get; set; }
        public string TomDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
