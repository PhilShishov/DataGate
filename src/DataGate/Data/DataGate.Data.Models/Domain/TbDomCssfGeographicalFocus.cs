namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomCssfGeographicalFocus
    {
        public TbDomCssfGeographicalFocus()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int GfId { get; set; }
        public string GfDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
