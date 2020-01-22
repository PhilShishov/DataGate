// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Base binding model for document file upload

// Created: 01/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels
{
    using Microsoft.AspNetCore.Http;

    public abstract class BaseUploadFileBindingModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
