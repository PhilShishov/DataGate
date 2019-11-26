namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomCssfGeographicalFocus
    {
        public TbDomCssfGeographicalFocus()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int GfId { get; set; }

        public string GfDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
