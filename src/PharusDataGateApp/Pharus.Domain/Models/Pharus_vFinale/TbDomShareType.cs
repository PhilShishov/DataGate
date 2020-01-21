using System;
using System.Collections.Generic;

namespace Pharus.Domain.Models.Pharus_vFinale
{
    public partial class TbDomShareType
    {
        public TbDomShareType()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
        }

        public int StId { get; set; }
        public string StDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
    }
}
