namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public partial class TbDomCompanyType
    {
        public TbDomCompanyType()
        {
            this.TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int CtId { get; set; }
        public string CtDesc { get; set; }
        public string CtAcronym { get; set; }

        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}
