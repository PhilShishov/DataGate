namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomSfStatus
    {
        public TbDomSfStatus()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int StId { get; set; }

        public string StDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
