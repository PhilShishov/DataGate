namespace DataGate.Web.ViewModels.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FundReportOverviewViewModel
    {
        [Required]
        public DateTime Date { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public List<string[]> Values { get; set; }
    }
}
