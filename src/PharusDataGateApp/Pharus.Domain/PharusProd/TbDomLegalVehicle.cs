using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomLegalVehicle
    {
        public TbDomLegalVehicle()
        {
            TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int LvId { get; set; }
        public string LvAcronym { get; set; }
        public int LvFkLegalType { get; set; }

        public virtual TbDomLegalType LvFkLegalTypeNavigation { get; set; }
        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}
