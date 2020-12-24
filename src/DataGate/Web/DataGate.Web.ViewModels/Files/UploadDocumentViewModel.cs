// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Files
{
    using Microsoft.AspNetCore.Http;

    public class UploadDocumentViewModel
    {
        public string DocumentType { get; set; }

        public string ControllerName { get; set; }

        public IFormFile FileToUpload { get; set; }
    }
}
