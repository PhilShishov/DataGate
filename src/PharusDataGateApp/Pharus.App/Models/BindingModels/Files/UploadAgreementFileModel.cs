// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for agreement file upload

// Created: 01/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.Files
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FoolProof.Core;
    using Microsoft.AspNetCore.Http;

    public class UploadAgreementFileModel
    {
        [Required]
        [Display(Name = "Agreement Type")]
        public string AgrType { get; set; }

        [Required(ErrorMessage = "Contract Date cannot be empty.")]
        //[LessThanOrEqualTo("ActivationDate", ErrorMessage = "Contract date cannot be after the activation date")]
        [Display(Name = "Contract Date")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "Activation Date cannot be empty.")]
        [Display(Name = "Activation Date")]
        public DateTime ActivationDate { get; set; }

        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please insert File.")]
        public IFormFile FileToUpload { get; set; }
    }
}
