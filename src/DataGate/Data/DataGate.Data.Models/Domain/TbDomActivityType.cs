namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

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
        public int AtEntity { get; set; }

        public virtual TbDomEntity AtEntityNavigation { get; set; }
        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
    }
}
