namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System;

    public partial class TbMapFileshareclass
    {
        public Guid FileStreamId { get; set; }
        public int ShareclassId { get; set; }
        public DateTime StartConnection { get; set; }
        public DateTime? EndConnection { get; set; }
        public int FiletypeId { get; set; }

        public virtual TbShareClass Shareclass { get; set; }
    }
}