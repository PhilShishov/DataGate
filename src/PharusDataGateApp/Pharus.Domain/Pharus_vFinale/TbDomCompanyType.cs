namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

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
