namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbShareclassTsTest
    {
        public DateTime DateTs { get; set; }
        public int IdTs { get; set; }
        public decimal? ValueTs { get; set; }
        public string CurrencyTs { get; set; }
        public int ProviderTs { get; set; }
        public int IdShareclass { get; set; }
        public string FileName { get; set; }

        public virtual TbDomIsoCurrency CurrencyTsNavigation { get; set; }
        public virtual TbShareClass IdShareclassNavigation { get; set; }
        public virtual TbDomTimeseriesType IdTsNavigation { get; set; }
        public virtual TbDomTimeseriesProvider ProviderTsNavigation { get; set; }
    }
}
