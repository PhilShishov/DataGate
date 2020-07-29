// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Abstract model class for bind entity
// for code reuse of different kinds -
// funds, subfunds and shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public abstract class BaseEntityInputModel
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Valid From")]
        public DateTime InitialDate { get; set; }

        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = ErrorMessages.UnvalidFormat)]
        [Display(Name = "CSSF Code")]
        public string CSSFCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ErrorMessages.UnvalidFormat)]
        [Display(Name = "Fund Admin Code")]
        [Required]
        public string FACode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ErrorMessages.UnvalidFormat)]
        [Display(Name = "Transfer Agent Code")]
        public string TACode { get; set; }

        [Display(Name = "LEI Code")]
        public string LEICode { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
