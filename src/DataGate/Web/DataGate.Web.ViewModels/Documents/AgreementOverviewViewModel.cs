// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Documents
{
    using System.Collections.Generic;

    public class AgreementOverviewViewModel
    {
        public IEnumerable<AgreementViewModel> Agreements { get; set; }

        public string AreaName { get; set; }

        public int ContainerId { get; set; }

        public string Date { get; set; }
    }
}
