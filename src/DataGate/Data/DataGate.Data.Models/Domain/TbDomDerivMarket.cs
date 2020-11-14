namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomDerivMarket
    {
        public TbDomDerivMarket()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int DmId { get; set; }
        public string DmDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
