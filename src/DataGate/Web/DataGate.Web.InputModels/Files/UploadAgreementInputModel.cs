// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for agreement file upload

// Created: 01/2020
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

    public class UploadAgreementInputModel : IMapFrom<LoadAgreementDto>
    {
        [Required]
        [Display(Name = "Agreement Type")]
        public string AgrType { get; set; }

        [Required(ErrorMessage = "Contract Date cannot be empty.")]
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

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(1 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf" })]
        public IFormFile FileToUpload { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string RouteName { get; set; }

        public string AreaName { get; set; }

        public IReadOnlyCollection<string> AgreementsFileTypes { get; set; }

        public IReadOnlyCollection<string> AgreementsStatus { get; set; }

        public IReadOnlyCollection<string> Companies { get; set; }
    }
}
