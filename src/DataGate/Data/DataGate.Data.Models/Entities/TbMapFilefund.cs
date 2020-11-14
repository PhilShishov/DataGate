namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbMapFilefund
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int DocFundId { get; set; }
        public DateTime DocStartConnection { get; set; }
        public DateTime? DocEndConnection { get; set; }
        public int DocFiletype { get; set; }

        public virtual TbDomFileType DocFiletypeNavigation { get; set; }
        public virtual TbFund DocFund { get; set; }
        public virtual TbFile File { get; set; }
    }
}
