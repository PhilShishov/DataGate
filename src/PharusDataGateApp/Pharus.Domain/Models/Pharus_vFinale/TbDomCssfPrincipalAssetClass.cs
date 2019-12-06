namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

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
