using System;
using System.Collections.Generic;

namespace Pharus.Models.Pharus_vFinale
{
    public partial class TbMapFileshareclass
    {
        public Guid FileStreamId { get; set; }
        public int ShareclassId { get; set; }
        public DateTime StartConnection { get; set; }
        public DateTime? EndConnection { get; set; }
        public int FiletypeId { get; set; }

        public virtual TbDomFileType Filetype { get; set; }
        public virtual TbShareClass Shareclass { get; set; }
    }
}
