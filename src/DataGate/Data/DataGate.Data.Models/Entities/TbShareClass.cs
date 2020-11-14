namespace DataGate.Data.Models.Entities
{
    using System.Collections.Generic;

    public partial class TbShareClass
    {
        public TbShareClass()
        {
            TbCountryDistributionShares = new HashSet<TbCountryDistributionShares>();
            TbHistoryShareClass = new HashSet<TbHistoryShareClass>();
            TbHistoryShareClassCopy = new HashSet<TbHistoryShareClassCopy>();
            TbMapFileshareclass = new HashSet<TbMapFileshareclass>();
            TbServiceAgreementShareclass = new HashSet<TbServiceAgreementShareclass>();
            TbShareclassTsTest = new HashSet<TbShareclassTsTest>();
            TbSubFundShareClass = new HashSet<TbSubFundShareClass>();
            TbTimeseriesShareclass = new HashSet<TbTimeseriesShareclass>();
        }

        public int IdSc { get; set; }

        public virtual TbPrimeShareClass TbPrimeShareClass { get; set; }
        public virtual ICollection<TbCountryDistributionShares> TbCountryDistributionShares { get; set; }
        public virtual ICollection<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual ICollection<TbHistoryShareClassCopy> TbHistoryShareClassCopy { get; set; }
        public virtual ICollection<TbMapFileshareclass> TbMapFileshareclass { get; set; }
        public virtual ICollection<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual ICollection<TbShareclassTsTest> TbShareclassTsTest { get; set; }
        public virtual ICollection<TbSubFundShareClass> TbSubFundShareClass { get; set; }
        public virtual ICollection<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
    }
}
