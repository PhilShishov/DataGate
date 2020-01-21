// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for agreement file upload

// Created: 01/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.Files
{
    using Microsoft.AspNetCore.Http;

    public class UploadAgreementFileModel
    {
        public IFormFile FileToUpload { get; set; }

        public string FileType { get; set; }
    }
}
