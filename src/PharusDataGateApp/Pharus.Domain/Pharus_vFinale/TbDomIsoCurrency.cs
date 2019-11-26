﻿namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomIsoCurrency
    {
        public TbDomIsoCurrency()
        {
            this.TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public string IsoCcyCode { get; set; }

        public string IsoCcyDesc { get; set; }

        public string IsoCcyDescEntity { get; set; }

        public int? IsoCcyNumeric { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
