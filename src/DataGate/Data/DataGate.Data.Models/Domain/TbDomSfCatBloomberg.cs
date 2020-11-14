namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomSfCatBloomberg
    {
        public TbDomSfCatBloomberg()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CatBloombergId { get; set; }
        public string CatBloombergDesc { get; set; }
        public string CatBloombergDescExpl { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
