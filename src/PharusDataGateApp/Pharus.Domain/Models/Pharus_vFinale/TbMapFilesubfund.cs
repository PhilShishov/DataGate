namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System;

    public partial class TbMapFilesubfund
    {
        public Guid FileStreamId { get; set; }

        public int SubfundId { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public int FiletypeId { get; set; }

        public virtual TbSubFund Subfund { get; set; }
    }
}