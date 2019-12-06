namespace Pharus.Domain.Models.Pharus_vFinale
{
    using System;

    public partial class TbMapFilefund
    {
        public Guid FileStreamId { get; set; }

        public int FundId { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public int FiletypeId { get; set; }

        public virtual TbDomFileType Filetype { get; set; }
    }
}