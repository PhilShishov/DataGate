// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Documents
{
    using System.Collections.Generic;

    public class DistinctOverviewViewModel
    {
        public IEnumerable<DistinctDocViewModel> Documents { get; set; }

        public IEnumerable<DistinctAgrViewModel> Agreements { get; set; }

        public string AreaName { get; set; }
    }
}
