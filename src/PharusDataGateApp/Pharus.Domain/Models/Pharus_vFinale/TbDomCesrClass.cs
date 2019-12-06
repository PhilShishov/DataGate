namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

    using Pharus.Domain.Models.Pharus_vFinale;

    public partial class TbDomCesrClass
    {
        public TbDomCesrClass()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CcId { get; set; }

        public string CDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}