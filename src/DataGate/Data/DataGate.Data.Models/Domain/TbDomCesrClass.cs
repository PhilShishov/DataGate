namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

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
