namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomSfCatBloomberg
    {
        public TbDomSfCatBloomberg()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CatBloombergId { get; set; }

        public string CatBloombergDesc { get; set; }

        public string CatBloombergDescExpl { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
