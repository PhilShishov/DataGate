namespace DataGate.Data.Models.Entities
{
    using System;

    using DataGate.Data.Models.Domain;

    public partial class TbMapFilefund
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public int FundId { get; set; }
        public DateTime StartConnection { get; set; }
        public DateTime? EndConnection { get; set; }
        public string FileExtension { get; set; }
        public int FiletypeId { get; set; }

        public virtual TbDomFileType Filetype { get; set; }
        public virtual TbFund Fund { get; set; }
    }
}
