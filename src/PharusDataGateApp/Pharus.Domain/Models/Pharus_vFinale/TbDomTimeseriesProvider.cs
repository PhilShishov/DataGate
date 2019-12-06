namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

    using Pharus.Domain.Models.Pharus_vFinale;

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