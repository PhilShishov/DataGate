﻿namespace Pharus.Domain.Pharus_vFinale
{
    using System;
    using System.Collections.Generic;

    public partial class TbShareClass
    {
        public TbShareClass()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
        }

        public int IdSc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
    }
}
