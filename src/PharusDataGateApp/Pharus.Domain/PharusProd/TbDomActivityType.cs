using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomActivityType
    {
        public TbDomActivityType()
        {
            TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
            TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
        }

        public int AtId { get; set; }
        public string AtDesc { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
    }
}
