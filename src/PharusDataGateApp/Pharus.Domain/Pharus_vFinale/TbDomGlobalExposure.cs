namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomGlobalExposure
    {
        public TbDomGlobalExposure()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int GeId { get; set; }

        public string GeDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
