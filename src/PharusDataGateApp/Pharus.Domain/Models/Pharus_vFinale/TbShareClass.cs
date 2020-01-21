using System;
using System.Collections.Generic;

namespace Pharus.Domain.Models.Pharus_vFinale
{
    public partial class TbShareClass
    {
        public TbShareClass()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbMapFileshareclass = new HashSet<TbMapFileshareclass>();
            TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public int IdSc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbMapFileshareclass> TbMapFileshareclass { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
