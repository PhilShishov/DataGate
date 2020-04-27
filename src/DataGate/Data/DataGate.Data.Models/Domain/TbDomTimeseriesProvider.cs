namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomTimeseriesProvider
    {
        public TbDomTimeseriesProvider()
        {
            this.TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public int IdProvider { get; set; }
        public string DescProvider { get; set; }

        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
