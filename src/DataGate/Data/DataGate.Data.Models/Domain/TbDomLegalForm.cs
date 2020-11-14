namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomLegalForm
    {
        public TbDomLegalForm()
        {
            TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int LfId { get; set; }
        public string LfAcronym { get; set; }

        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}
