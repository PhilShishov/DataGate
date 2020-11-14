namespace DataGate.Data.Models.Entities
{
    using System.Collections.Generic;

    public partial class TbFile
    {
        public TbFile()
        {
            TbMapFilefund = new HashSet<TbMapFilefund>();
            TbMapFileshareclass = new HashSet<TbMapFileshareclass>();
            TbMapFilesubfund = new HashSet<TbMapFilesubfund>();
        }

        public int FileId { get; set; }

        public virtual TbServiceAgreementFund TbServiceAgreementFund { get; set; }
        public virtual TbServiceAgreementShareclass TbServiceAgreementShareclass { get; set; }
        public virtual TbServiceAgreementSubfund TbServiceAgreementSubfund { get; set; }
        public virtual ICollection<TbMapFilefund> TbMapFilefund { get; set; }
        public virtual ICollection<TbMapFileshareclass> TbMapFileshareclass { get; set; }
        public virtual ICollection<TbMapFilesubfund> TbMapFilesubfund { get; set; }
    }
}
