using DataGate.Data.Models.Domain;
using System;
using System.Collections.Generic;

namespace DataGate.Data.Models.Entities
{
    public partial class TbServiceAgreementShareclass
    {
        public int SaId { get; set; }
        public string FileName { get; set; }
        public int SaShareclassId { get; set; }
        public string FileExtension { get; set; }
        public int SaActivityType { get; set; }
        public DateTime SaContractDate { get; set; }
        public DateTime? SaActivationDate { get; set; }
        public DateTime? SaExpirationDate { get; set; }
        public int? SaCompanyId { get; set; }
        public string SaStatus { get; set; }

        public virtual TbDomActivityType SaActivityTypeNavigation { get; set; }
        public virtual TbCompanies SaCompany { get; set; }
        public virtual TbShareClass SaShareclass { get; set; }
    }
}
