﻿using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
{
    public partial class TbCompanies
    {
        public TbCompanies()
        {
            TbServiceAgreementFund = new HashSet<TbServiceAgreementFund>();
            TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            TbServiceAgreementSubfund = new HashSet<TbServiceAgreementSubfund>();
        }

        public int CId { get; set; }
        public string CName { get; set; }

        public virtual ICollection<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
    }
}
