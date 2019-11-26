namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomShareType
    {
        public TbDomShareType()
        {
            this.TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
        }

        public int StId { get; set; }

        public string StDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
    }
}
