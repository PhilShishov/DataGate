namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

    using Pharus.Domain.Models.Pharus_vFinale;

    public partial class TbDomInvestorType
    {
        public TbDomInvestorType()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
        }

        public int ItId { get; set; }

        public string ItDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
    }
}