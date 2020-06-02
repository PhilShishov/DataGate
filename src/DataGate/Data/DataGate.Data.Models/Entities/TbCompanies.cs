namespace DataGate.Data.Models.Entities
{
    using System.Collections.Generic;

    public partial class TbCompanies
    {
        public TbCompanies()
        {
            this.TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
            this.TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            this.TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
        }

        public int CId { get; set; }
        public string CName { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
    }
}
