using System;
using System.Collections.Generic;

namespace DataGate.Domain.Models.Pharus_vFinale
{
    public partial class TbDomAgreementStatus
    {
        public TbDomAgreementStatus()
        {
            TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
        }

        public int ASId { get; set; }
        public string ASDesc { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
    }
}
