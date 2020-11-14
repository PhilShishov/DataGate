namespace DataGate.Data.Models.Entities
{
    using DataGate.Data.Models.Domain;

    public partial class TbCountryDistributionShares
    {
        public int ShareId { get; set; }
        public string IsoCountry2 { get; set; }
        public int? LocalRepresentative { get; set; }
        public int? PayingAgent { get; set; }
        public int? LegalSupport { get; set; }
        public string Language { get; set; }

        public virtual TbDomIsoCountry IsoCountry2Navigation { get; set; }
        public virtual TbDomLanguages LanguageNavigation { get; set; }
        public virtual TbShareClass Share { get; set; }
    }
}
