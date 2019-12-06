using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
    public partial class TbDomFileType
    {
        public TbDomFileType()
        {
            TbMapFilefund = new HashSet<TbMapFilefund>();
        }

        public int FiletypeId { get; set; }
        public string FiletypeDesc { get; set; }
        public int FiletypeEntity { get; set; }

        public virtual TbDomEntity FiletypeEntityNavigation { get; set; }
        public virtual ICollection<TbMapFilefund> TbMapFilefund { get; set; }
    }
}
