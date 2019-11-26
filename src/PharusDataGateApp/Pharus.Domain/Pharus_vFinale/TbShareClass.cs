namespace Pharus.Domain.Pharus_vFinale
{
    using System;
    using System.Collections.Generic;

    public partial class TbShareClass
    {
        public TbShareClass()
        {
            this.TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            this.TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            this.TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
        }

        public int IdSc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }

        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }

        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
    }
}
