namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbServiceAgreementShareclass
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int SaShareclassId { get; set; }
        public int SaActivityType { get; set; }
        public DateTime SaContractDate { get; set; }
        public DateTime SaActivationDate { get; set; }
        public DateTime? SaExpirationDate { get; set; }
        public int SaStatus { get; set; }
        public int SaCompany { get; set; }

        public virtual TbFile File { get; set; }
        public virtual TbDomActivityType SaActivityTypeNavigation { get; set; }
        public virtual TbCompanies SaCompanyNavigation { get; set; }
        public virtual TbShareClass SaShareclass { get; set; }
        public virtual TbDomAgreementStatus SaStatusNavigation { get; set; }
    }
}
