namespace Pharus.Domain.Pharus_vFinale
{
    using System.Collections.Generic;

    public partial class TbDomLegalType
    {
        public TbDomLegalType()
        {
            this.TbDomLegalVehicle = new HashSet<TbDomLegalVehicle>();
        }

        public int LtId { get; set; }

        public string LtAcronym { get; set; }

        public virtual ICollection<TbDomLegalVehicle> TbDomLegalVehicle { get; set; }
    }
}
