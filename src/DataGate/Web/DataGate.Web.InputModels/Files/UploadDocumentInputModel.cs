// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Files
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class UploadDocumentInputModel : IMapFrom<LoadDocumentDto>
    {
        public UploadDocumentInputModel()
        {
            this.DocumentTypes = new List<string>();
        }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Document Type")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = ValidationMessages.FileRequired)]
        [DataType(DataType.Upload)]
        [MaxFileSize(GlobalConstants.FileSizeLimit)]
        [AllowedExtensions(new string[] { GlobalConstants.PdfFileExtension })]
        public IFormFile FileToUpload { get; set; }

        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string RouteName { get; set; }

        public string AreaName { get; set; }

        public IReadOnlyCollection<string> DocumentTypes { get; set; }
    }
}
