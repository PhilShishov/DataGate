namespace DataGate.Web.ViewModels.Reports
{
    using System.Collections.Generic;

    public class FundReportViewModel
    {
        public int FundId { get; set; }

        public string FundName { get; set; }

        public IEnumerable<decimal> AuMPerMonth { get; set; }
    }
}
