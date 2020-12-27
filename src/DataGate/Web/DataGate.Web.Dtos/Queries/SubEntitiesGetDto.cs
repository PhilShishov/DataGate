// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    using System.Collections.Generic;

    public class SubEntitiesGetDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public IEnumerable<string[]> Values { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public IEnumerable<string> HeadersSelection { get; set; }

        public string Container { get; set; }
    }
}
