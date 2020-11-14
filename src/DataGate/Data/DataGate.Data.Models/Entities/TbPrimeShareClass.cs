namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbPrimeShareClass
    {
        public int ScId { get; set; }
        public DateTime ScInitialDate { get; set; }
        public DateTime? ScEndDate { get; set; }
        public string ScOfficialShareClassName { get; set; }
        public string ScShortShareClassName { get; set; }
        public int? ScInvestorType { get; set; }
        public int? ScShareType { get; set; }
        public string ScCurrency { get; set; }
        public string ScCountryIssue { get; set; }
        public string ScUltimateParentCountryRisk { get; set; }
        public DateTime? ScEmissionDate { get; set; }
        public DateTime? ScInceptionDate { get; set; }
        public DateTime? ScLastNav { get; set; }
        public DateTime? ScExpiryDate { get; set; }
        public int? ScStatus { get; set; }
        public double? ScInitialPrice { get; set; }
        public string ScAccountingCode { get; set; }
        public bool? ScHedged { get; set; }
        public bool? ScListed { get; set; }
        public string ScBloomberMarket { get; set; }
        public string ScBloombedCode { get; set; }
        public string ScBloombedId { get; set; }
        public string ScIsinCode { get; set; }
        public string ScValorCode { get; set; }
        public string ScFaCode { get; set; }
        public string ScTaCode { get; set; }
        public string ScWkn { get; set; }
        public DateTime? ScDateBusinessYear { get; set; }
        public string ScProspectusCode { get; set; }
        public string ScChangeComment { get; set; }
        public string ScCommentTitle { get; set; }

        public virtual TbShareClass Sc { get; set; }
        public virtual TbDomIsoCountry ScCountryIssueNavigation { get; set; }
        public virtual TbDomIsoCurrency ScCurrencyNavigation { get; set; }
        public virtual TbDomInvestorType ScInvestorTypeNavigation { get; set; }
        public virtual TbDomShareType ScShareTypeNavigation { get; set; }
        public virtual TbDomShareStatus ScStatusNavigation { get; set; }
    }
}
