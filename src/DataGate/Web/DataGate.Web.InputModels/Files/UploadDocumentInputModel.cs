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

        [Required]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(1 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf" })]
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
