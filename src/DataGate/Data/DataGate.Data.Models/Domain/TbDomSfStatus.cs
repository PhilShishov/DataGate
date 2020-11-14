namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomSfStatus
    {
        public TbDomSfStatus()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int StId { get; set; }
        public string StDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
