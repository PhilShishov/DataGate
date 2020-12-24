// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class AuMReportViewModel
    {
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public DateTime Date { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public List<string[]> Values { get; set; }
    }
}
