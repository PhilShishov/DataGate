namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomIsoCurrency
    {
        public TbDomIsoCurrency()
        {
            this.TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
            this.TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public string IsoCcyCode { get; set; }
        public string IsoCcyDesc { get; set; }
        public string IsoCcyDescEntity { get; set; }
        public int? IsoCcyNumeric { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
