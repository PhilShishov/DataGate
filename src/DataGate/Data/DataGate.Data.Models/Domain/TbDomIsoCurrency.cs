namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomIsoCurrency
    {
        public TbDomIsoCurrency()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbHistoryShareClassCopy = new HashSet<TbHistoryShareClassCopy>();
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
            TbShareclassTsTest = new HashSet<TbShareclassTsTest>();
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
            TbTimeseriesSubfund = new HashSet<TbTimeseriesSubfund>();
        }

        public string IsoCcyCode { get; set; }
        public string IsoCcyDesc { get; set; }
        public string IsoCcyDescEntity { get; set; }
        public int? IsoCcyNumeric { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbHistoryShareClassCopy> TbHistoryShareClassCopy { get; set; }
        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbPrimeShareClass> TbPrimeShareClass { get; set; }
        public virtual ICollection<TbShareclassTsTest> TbShareclassTsTest { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
        public virtual ICollection<TbTimeseriesSubfund> TbTimeseriesSubfund { get; set; }
    }
}
