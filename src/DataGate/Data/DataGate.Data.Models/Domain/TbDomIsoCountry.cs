namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomIsoCountry
    {
        public TbDomIsoCountry()
        {
            TbCountryDistributionShares = new HashSet<TbCountryDistributionShares>();
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbHistoryShareClassCopy = new HashSet<TbHistoryShareClassCopy>();
        }

        public string IsoCountryIso2 { get; set; }
        public string IsoCountryDesc { get; set; }
        public string IsoCountry3 { get; set; }

        public virtual ICollection<TbCountryDistributionShares> TbCountryDistributionShares { get; set; }
        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbHistoryShareClassCopy> TbHistoryShareClassCopy { get; set; }
        public virtual ICollection<TbPrimeShareClass> TbPrimeShareClass { get; set; }
    }
}
