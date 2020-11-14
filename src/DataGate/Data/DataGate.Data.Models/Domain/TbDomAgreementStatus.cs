namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomAgreementStatus
    {
        public TbDomAgreementStatus()
        {
            TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
            TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
        }

        public int ASId { get; set; }
        public string ASDesc { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
    }
}
