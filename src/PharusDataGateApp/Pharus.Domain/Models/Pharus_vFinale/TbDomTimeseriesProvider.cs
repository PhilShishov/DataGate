using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
    public partial class TbDomTimeseriesProvider
    {
        public TbDomTimeseriesProvider()
        {
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public int IdProvider { get; set; }
        public string DescProvider { get; set; }

        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
