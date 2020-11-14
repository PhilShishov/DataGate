namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbHistoryFund
    {
        public int FId { get; set; }
        public DateTime FInitialDate { get; set; }
        public DateTime? FEndDate { get; set; }
        public int? FStatus { get; set; }
        public string FRegistrationNumber { get; set; }
        public string FOfficialFundName { get; set; }
        public string FShortFundName { get; set; }
        public string FLeiCode { get; set; }
        public string FCssfCode { get; set; }
        public string FFaCode { get; set; }
        public string FDepCode { get; set; }
        public string FTaCode { get; set; }
        public int? FLegalForm { get; set; }
        public int? FLegalType { get; set; }
        public int? FLegalVehicle { get; set; }
        public int? FCompanyType { get; set; }
        public string FTinNumber { get; set; }
        public string FChangeComment { get; set; }
        public string FCommentTitle { get; set; }

        public virtual TbFund F { get; set; }
        public virtual TbDomCompanyType FCompanyTypeNavigation { get; set; }
        public virtual TbDomLegalForm FLegalFormNavigation { get; set; }
        public virtual TbDomLegalVehicle FLegalVehicleNavigation { get; set; }
        public virtual TbDomFStatus FStatusNavigation { get; set; }
    }
}
