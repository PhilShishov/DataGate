﻿using System;
using System.Collections.Generic;

namespace DataGate.Data.Models.Entities
{
    public partial class TbFundSubFund
    {
        public int SfId { get; set; }
        public int FId { get; set; }
        public DateTime FsfStartConnection { get; set; }
        public DateTime? FsfEndConnection { get; set; }

        public virtual TbFund F { get; set; }
        public virtual TbSubFund Sf { get; set; }
    }
}
