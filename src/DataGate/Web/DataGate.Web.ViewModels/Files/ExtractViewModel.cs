// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Files
{
    using System.Collections.Generic;

    public class ExtractViewModel
    {
        public List<string> Headers { get; set; }

        public List<string> Names { get; set; }

        public List<string[]> Values { get; set; }
    }
}
