namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomSfCatMorningstar
    {
        public TbDomSfCatMorningstar()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CMorningstarId { get; set; }

        public string CMorningstarDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
