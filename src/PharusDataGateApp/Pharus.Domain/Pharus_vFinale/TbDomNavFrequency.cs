namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomNavFrequency
    {
        public TbDomNavFrequency()
        {
            this.TbHistorySubFund = new HashSet<TbHistorySubFund>();
        }

        public int NfId { get; set; }

        public string NfDesc { get; set; }

        public virtual ICollection<TbHistorySubFund> TbHistorySubFund { get; set; }
    }
}
