using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
    public partial class TbDomEntity
    {
        public TbDomEntity()
        {
            TbDomFileType = new HashSet<TbDomFileType>();
            TbDomTimeseriesType = new HashSet<TbDomTimeseriesType>();
        }

        public int EntityId { get; set; }
        public string EntityDesc { get; set; }

        public virtual ICollection<TbDomFileType> TbDomFileType { get; set; }
        public virtual ICollection<TbDomTimeseriesType> TbDomTimeseriesType { get; set; }
    }
}
