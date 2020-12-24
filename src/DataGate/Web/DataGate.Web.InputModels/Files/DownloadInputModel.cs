// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Files
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class DownloadInputModel
    {
        public List<string[]> TableValues { get; set; }

        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public string Date { get; set; }

        public string ControllerName { get; set; }

        public string TargetUrl { get; set; }

        public string Command { get; set; }
    }
}
