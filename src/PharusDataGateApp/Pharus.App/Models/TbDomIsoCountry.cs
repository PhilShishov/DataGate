using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
    public partial class TbDomIsoCountry
    {
        public TbDomIsoCountry()
        {
            TbHistoryShareClassScCountryIssueNavigation = new HashSet<TbHistoryShareClass>();
            TbHistoryShareClassScUltimateParentCountryRiskNavigation = new HashSet<TbHistoryShareClass>();
        }

        public string IsoCountryIso2 { get; set; }
        public string IsoCountryDesc { get; set; }
        public string IsoCountry3 { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClassScCountryIssueNavigation { get; set; }
        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClassScUltimateParentCountryRiskNavigation { get; set; }
    }
}
