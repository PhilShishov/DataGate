namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;
    public partial class TbDomCssfPrincipalAssetClass
    {
        public TbDomCssfPrincipalAssetClass()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int PacId { get; set; }
        public string PacDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
