﻿using System;
using System.Collections.Generic;

namespace Pharus.Domain.PharusProd
{
    public partial class TbDomSfCatSix
    {
        public TbDomSfCatSix()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int CatSixId { get; set; }
        public string CatSixDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}