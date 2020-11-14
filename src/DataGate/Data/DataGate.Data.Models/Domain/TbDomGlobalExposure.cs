namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomGlobalExposure
    {
        public TbDomGlobalExposure()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int GeId { get; set; }
        public string GeDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
