﻿using System;
using System.Collections.Generic;

namespace Pharus.Domain.Models.Pharus_vFinale
{
    public partial class TbDomEntity
    {
        public TbDomEntity()
        {
            TbDomActivityType = new HashSet<TbDomActivityType>();
            TbDomFileType = new HashSet<TbDomFileType>();
            TbDomTimeseriesType = new HashSet<TbDomTimeseriesType>();
        }

        public int EntityId { get; set; }
        public string EntityDesc { get; set; }

        public virtual ICollection<TbDomActivityType> TbDomActivityType { get; set; }
        public virtual ICollection<TbDomFileType> TbDomFileType { get; set; }
        public virtual ICollection<TbDomTimeseriesType> TbDomTimeseriesType { get; set; }
    }
}
