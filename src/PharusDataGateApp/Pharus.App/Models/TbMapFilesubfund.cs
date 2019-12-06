using System;
using System.Collections.Generic;

namespace Pharus.App.Models
{
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
