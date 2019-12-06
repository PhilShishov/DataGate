namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomValutationDate
    {
        public TbDomValutationDate()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int VdId { get; set; }

        public string VdDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}