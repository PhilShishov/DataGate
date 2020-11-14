namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomValutationDate
    {
        public TbDomValutationDate()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
            TbMapNavFrequencyValuation = new HashSet<TbMapNavFrequencyValuation>();
        }

        public int VdId { get; set; }
        public string VdDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbMapNavFrequencyValuation> TbMapNavFrequencyValuation { get; set; }
    }
}
