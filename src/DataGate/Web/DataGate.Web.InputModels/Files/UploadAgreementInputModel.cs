// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Files
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Documents;
    using DataGate.Web.Infrastructure.Attributes.Validation;
    using Microsoft.AspNetCore.Http;

    public class UploadAgreementInputModel : IMapFrom<LoadAgreementDto>, IMapTo<OnUploadSuccessDto>
    {
        [Required(ErrorMessage = ValidationMessages.AgrTypeRequired)]
        [Display(Name = "Agreement Type")]
        public string AgrType { get; set; }

        [Display(Name = "Contract Date")]
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public string ContractDate { get; set; }

        [Display(Name = "Activation Date")]
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public string ActivationDate { get; set; }

        [Display(Name = "Expiration Date")]
        public string ExpirationDate { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Status { get; set; }

        [Required(ErrorMessage = ValidationMessages.FileRequired)]
        [DataType(DataType.Upload)]
        [MaxFileSize(GlobalConstants.FileSizeLimit)]
        [AllowedExtensions(new string[] { GlobalConstants.PdfFileExtension })]
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
