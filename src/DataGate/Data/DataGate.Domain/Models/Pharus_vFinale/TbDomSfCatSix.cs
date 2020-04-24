using System;
using System.Collections.Generic;

namespace DataGate.Domain.Models.Pharus_vFinale
{
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
