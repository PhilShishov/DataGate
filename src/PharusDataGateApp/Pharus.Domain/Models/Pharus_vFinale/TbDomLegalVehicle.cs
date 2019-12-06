﻿namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomLegalVehicle
    {
        public TbDomLegalVehicle()
        {
            TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int LvId { get; set; }

        public string LvAcronym { get; set; }

        public int LvFkLegalType { get; set; }

        public virtual TbDomLegalType LvFkLegalTypeNavigation { get; set; }

        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}