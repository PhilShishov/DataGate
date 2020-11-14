namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

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
