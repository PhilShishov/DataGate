using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
    public partial class TbDomTimeseriesType
    {
        public TbDomTimeseriesType()
        {
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public int IdTs { get; set; }
        public string DescTs { get; set; }
        public int EntityType { get; set; }

        public virtual TbDomEntity EntityTypeNavigation { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
