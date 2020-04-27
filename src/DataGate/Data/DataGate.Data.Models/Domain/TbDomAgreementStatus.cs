namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomAgreementStatus
    {
        public TbDomAgreementStatus()
        {
            this.TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
        }

        public int ASId { get; set; }
        public string ASDesc { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
    }
}
