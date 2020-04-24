using System;
using System.Collections.Generic;

namespace DataGate.Domain.Models.Pharus_vFinale
{
    public partial class TbServiceAgreementSubfund
    {
        public int SaId { get; set; }
        public int SaSubfundId { get; set; }
        public int SaActivityType { get; set; }
        public DateTime SaContractDate { get; set; }
        public DateTime? SaActivationDate { get; set; }
        public DateTime? SaExpirationDate { get; set; }
        public string SaRifCode { get; set; }
        public int? SaCompanyId { get; set; }
        public string SaStatus { get; set; }

        public virtual TbDomActivityType SaActivityTypeNavigation { get; set; }
        public virtual TbCompanies SaCompany { get; set; }
        public virtual TbSubFund SaSubfund { get; set; }
    }
}
