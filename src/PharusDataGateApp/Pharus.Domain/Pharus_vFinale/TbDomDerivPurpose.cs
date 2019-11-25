﻿using System;
using System.Collections.Generic;

namespace Pharus.Domain.Pharus_vFinale
{
    public partial class TbDomDerivPurpose
    {
        public TbDomDerivPurpose()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int DpId { get; set; }
        public string DpDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}