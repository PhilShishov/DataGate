namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomPrincipalInvestmentStrategy
    {
        public TbDomPrincipalInvestmentStrategy()
        {
            TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int PisId { get; set; }
        public string PisDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
