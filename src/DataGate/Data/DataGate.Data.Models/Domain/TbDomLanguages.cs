namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomLanguages
    {
        public TbDomLanguages()
        {
            TbCountryDistributionShares = new HashSet<TbCountryDistributionShares>();
        }

        public string LanguageIso3 { get; set; }
        public string LanguageDesc { get; set; }

        public virtual ICollection<TbCountryDistributionShares> TbCountryDistributionShares { get; set; }
    }
}
