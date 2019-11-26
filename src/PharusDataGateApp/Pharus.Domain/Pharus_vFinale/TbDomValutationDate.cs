namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomValutationDate
    {
        public TbDomValutationDate()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int VdId { get; set; }

        public string VdDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
