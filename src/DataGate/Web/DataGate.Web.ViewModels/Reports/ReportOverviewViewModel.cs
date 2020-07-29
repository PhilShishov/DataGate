namespace DataGate.Web.ViewModels.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class ReportOverviewViewModel
    {
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public DateTime Date { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<ReportViewModel> Reports { get; set; }

        public List<string[]> FundReports { get; set; }
    }
}
