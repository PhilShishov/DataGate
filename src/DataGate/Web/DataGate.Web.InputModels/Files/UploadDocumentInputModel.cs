// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for document file upload

// Created: 12/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.InputModels.Files
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class UploadDocumentInputModel
    {

        [Required]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Please insert File.")]
        public IFormFile FileToUpload { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string ControllerName { get; set; }
    }
}
