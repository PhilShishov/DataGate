namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomLegalForm
    {
        public TbDomLegalForm()
        {
            this.TbHistoryFund = new HashSet<TbHistoryFund>();
        }

        public int LfId { get; set; }

        public string LfAcronym { get; set; }

        public virtual ICollection<TbHistoryFund> TbHistoryFund { get; set; }
    }
}
