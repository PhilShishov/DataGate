namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public partial class TbDomShareStatus
    {
        public TbDomShareStatus()
        {
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbHistoryShareClassCopy = new HashSet<TbHistoryShareClassCopy>();
        }

        public int ScSId { get; set; }
        public string ScSDesc { get; set; }

        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbHistoryShareClassCopy> TbHistoryShareClassCopy { get; set; }
        public virtual ICollection<TbPrimeShareClass> TbPrimeShareClass { get; set; }
    }
}
