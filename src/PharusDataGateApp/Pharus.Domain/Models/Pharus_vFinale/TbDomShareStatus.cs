using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
{
    public partial class TbDomShareStatus
    {
        public TbDomShareStatus()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
        }

        public int ScSId { get; set; }
        public string ScSDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
    }
}
