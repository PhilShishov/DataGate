namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomTimeseriesType
    {
        public TbDomTimeseriesType()
        {
            TbShareclassTsTest = new HashSet<TbShareclassTsTest>();
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
            TbTimeseriesSubfund = new HashSet<TbTimeseriesSubfund>();
        }

        public int IdTs { get; set; }
        public string DescTs { get; set; }
        public int EntityType { get; set; }

        public virtual TbDomEntity EntityTypeNavigation { get; set; }
        public virtual ICollection<TbShareclassTsTest> TbShareclassTsTest { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
        public virtual ICollection<TbTimeseriesSubfund> TbTimeseriesSubfund { get; set; }
    }
}
