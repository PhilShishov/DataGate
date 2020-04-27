﻿namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomSfCatMorningstar
    {
        public TbDomSfCatMorningstar()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CMorningstarId { get; set; }
        public string CMorningstarDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
