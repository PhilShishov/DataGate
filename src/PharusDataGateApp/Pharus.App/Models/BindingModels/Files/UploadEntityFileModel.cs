// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for document file upload

// Created: 12/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.Files
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    public class UploadEntityFileModel
    {
        public string DocumentType { get; set; }

        public IFormFile FileToUpload { get; set; }
    }
}
