// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Agreements
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class AgreementsLibraryOverviewViewModel
    {
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public string Date { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<AgreementLibraryViewModel> Agreements { get; set; }
    }
}
