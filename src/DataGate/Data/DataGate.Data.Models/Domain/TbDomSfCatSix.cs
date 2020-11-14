namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomSfCatSix
    {
        public TbDomSfCatSix()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CatSixId { get; set; }
        public string CatSixDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
