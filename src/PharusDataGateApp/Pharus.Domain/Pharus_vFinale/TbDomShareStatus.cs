namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomShareStatus
    {
        public TbDomShareStatus()
        {
            this.TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
        }

        public int ScSId { get; set; }

        public string ScSDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
    }
}
