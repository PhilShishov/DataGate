namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomTimeseriesProvider
    {
        public TbDomTimeseriesProvider()
        {
            TbShareclassTsTest = new HashSet<TbShareclassTsTest>();
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
            TbTimeseriesSubfund = new HashSet<TbTimeseriesSubfund>();
        }

        public int IdProvider { get; set; }
        public string DescProvider { get; set; }

        public virtual ICollection<TbShareclassTsTest> TbShareclassTsTest { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
        public virtual ICollection<TbTimeseriesSubfund> TbTimeseriesSubfund { get; set; }
    }
}
