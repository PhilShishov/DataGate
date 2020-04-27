using DataGate.Data.Models.Domain;
using System;
using System.Collections.Generic;

namespace DataGate.Data.Models.Entities
{
    public partial class TbMapFileshareclass
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public int ShareclassId { get; set; }
        public DateTime StartConnection { get; set; }
        public DateTime? EndConnection { get; set; }
        public string FileExtension { get; set; }
        public int FiletypeId { get; set; }

        public virtual TbDomFileType Filetype { get; set; }
        public virtual TbShareClass Shareclass { get; set; }
    }
}
