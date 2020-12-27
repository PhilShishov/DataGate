// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Queries
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Entities;

    public class AllDto : IMapFrom<EntitiesViewModel>, IMapFrom<SubEntitiesViewModel>
    {
        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public string Area { get; set; }

        public string FunctionActive { get; set; }

        public string FunctionAll { get; set; }

        public string Container { get; set; }

        public IEnumerable<string[]> Entities { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public IEnumerable<string[]> Values { get; set; }

        public IEnumerable<string> HeadersSelection { get; set; }

    }
}
