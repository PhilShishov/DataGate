// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for document file upload

// Created: 12/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.InputModels.Files
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using Microsoft.AspNetCore.Http;

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

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string RouteName { get; set; }

        public string AreaName { get; set; }

        public IReadOnlyCollection<string> DocumentTypes { get; set; }
    }
}
