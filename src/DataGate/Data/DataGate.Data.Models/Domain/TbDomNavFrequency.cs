namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomNavFrequency
    {
        public TbDomNavFrequency()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
            TbMapNavFrequencyValuation = new HashSet<TbMapNavFrequencyValuation>();
        }

        public int NfId { get; set; }
        public string NfDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbMapNavFrequencyValuation> TbMapNavFrequencyValuation { get; set; }
    }
}
