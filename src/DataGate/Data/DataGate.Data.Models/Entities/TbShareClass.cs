using System;
using System.Collections.Generic;

namespace DataGate.Data.Models.Entities
{
    public partial class TbShareClass
    {
        public TbShareClass()
        {
            this.TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            this.TbMapFileshareclass = new HashSet<TbMapFileshareclass>();
            this.TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            this.TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
            this.TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public int IdSc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbMapFileshareclass> TbMapFileshareclass { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
