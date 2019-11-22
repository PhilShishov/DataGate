using System;
using System.Collections.Generic;

namespace Pharus.Domain.Pharus_vFinale
{
    public partial class TbDomLegalType
    {
        public TbDomLegalType()
        {
            TbDomLegalVehicle = new HashSet<TbDomLegalVehicle>();
        }

        public int LtId { get; set; }
        public string LtAcronym { get; set; }

        public virtual ICollection<TbDomLegalVehicle> TbDomLegalVehicle { get; set; }
    }
}
