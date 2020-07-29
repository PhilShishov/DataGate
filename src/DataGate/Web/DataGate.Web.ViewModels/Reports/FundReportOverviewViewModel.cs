﻿namespace DataGate.Web.ViewModels.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class FundReportOverviewViewModel
    {
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public DateTime Date { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public List<string[]> Values { get; set; }
    }
}
