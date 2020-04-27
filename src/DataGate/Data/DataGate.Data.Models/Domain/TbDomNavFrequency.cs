namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomNavFrequency
    {
        public TbDomNavFrequency()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int NfId { get; set; }
        public string NfDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
