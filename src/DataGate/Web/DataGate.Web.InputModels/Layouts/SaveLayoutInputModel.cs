// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Layouts
{
    using System.Collections.Generic;

    public class SaveLayoutInputModel
    {
        public IEnumerable<string> SelectedColumns { get; set; }

        public string ControllerName { get; set; }

        public string AreaOrigin { get; set; }
    }
}