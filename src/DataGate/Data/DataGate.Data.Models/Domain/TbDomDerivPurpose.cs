﻿namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomDerivPurpose
    {
        public TbDomDerivPurpose()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int DpId { get; set; }
        public string DpDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
