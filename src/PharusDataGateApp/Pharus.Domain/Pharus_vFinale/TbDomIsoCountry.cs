namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomIsoCountry
    {
        public TbDomIsoCountry()
        {
            this.TbHistoryShareClassScCountryIssueNavigation = new HashSet<TbHistoryShareClass>();
            this.TbHistoryShareClassScUltimateParentCountryRiskNavigation = new HashSet<TbHistoryShareClass>();
        }

        public string IsoCountryIso2 { get; set; }

        public string IsoCountryDesc { get; set; }

        public string IsoCountry3 { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClassScCountryIssueNavigation { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClassScUltimateParentCountryRiskNavigation { get; set; }
    }
}
