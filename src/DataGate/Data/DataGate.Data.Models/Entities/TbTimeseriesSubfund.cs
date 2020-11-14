namespace DataGate.Data.Models.Entities
{
    using System;
    using DataGate.Data.Models.Domain;

    public partial class TbTimeseriesSubfund
    {
        public DateTime DateTs { get; set; }
        public int IdTs { get; set; }
        public decimal? ValueTs { get; set; }
        public string CurrencyTs { get; set; }
        public int ProviderTs { get; set; }
        public int IdSubfund { get; set; }

        public virtual TbDomIsoCurrency CurrencyTsNavigation { get; set; }
        public virtual TbSubFund IdSubfundNavigation { get; set; }
        public virtual TbDomTimeseriesType IdTsNavigation { get; set; }
        public virtual TbDomTimeseriesProvider ProviderTsNavigation { get; set; }
    }
}
