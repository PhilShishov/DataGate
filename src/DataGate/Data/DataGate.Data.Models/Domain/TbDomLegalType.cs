namespace DataGate.Data.Models.Domain
{
    using System.Collections.Generic;

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
