namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

    public partial class TbDomEntity
    {
        public TbDomEntity()
        {
            this.TbDomActivityType = new HashSet<TbDomActivityType>();
            this.TbDomFileType = new HashSet<TbDomFileType>();
            this.TbDomTimeseriesType = new HashSet<TbDomTimeseriesType>();
        }

        public int EntityId { get; set; }
        public string EntityDesc { get; set; }

        public virtual ICollection<TbDomActivityType> TbDomActivityType { get; set; }
        public virtual ICollection<TbDomFileType> TbDomFileType { get; set; }
        public virtual ICollection<TbDomTimeseriesType> TbDomTimeseriesType { get; set; }
    }
}
