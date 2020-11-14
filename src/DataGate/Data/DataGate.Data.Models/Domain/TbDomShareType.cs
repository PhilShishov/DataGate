namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomShareType
    {
        public TbDomShareType()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbHistoryShareClassCopy = new HashSet<TbHistoryShareClassCopy>();
        }

        public int StId { get; set; }
        public string StDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbHistoryShareClassCopy> TbHistoryShareClassCopy { get; set; }
        public virtual ICollection<TbPrimeShareClass> TbPrimeShareClass { get; set; }
    }
}
