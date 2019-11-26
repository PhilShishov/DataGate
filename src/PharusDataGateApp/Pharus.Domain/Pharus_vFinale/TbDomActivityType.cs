namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomActivityType
    {
        public TbDomActivityType()
        {
            this.TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
            this.TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            this.TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
        }

        public int AtId { get; set; }

        public string AtDesc { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }

        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }

        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
    }
}
