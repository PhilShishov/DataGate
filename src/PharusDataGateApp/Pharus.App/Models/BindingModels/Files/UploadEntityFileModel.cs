// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for document file upload

// Created: 12/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.Files
{

    using System.ComponentModel.DataAnnotations;
    public class UploadEntityFileModel : BaseUploadFileBindingModel
    {
        [Required]
        public string DocumentType { get; set; }
    }
}
