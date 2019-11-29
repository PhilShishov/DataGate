// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Model class for create fund

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.Funds
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateFundBindingModel
    {
        [Required(ErrorMessage = "Initial Date cannot be null")]
        [Display(Name = "Initial Date")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "You must enter a value for the Fund Name!")]
        [StringLength(200, ErrorMessage = "The Fund Name must be no longer than 200 characters")]
        [RegularExpression(@"^[A-Z0-9\- ]+$")]
        [Display(Name = "Fund Name")]
        public string FundName { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "CSSF Code")]
        public string CSSFCode { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string FStatus { get; set; }

        [Required]
        [Display(Name = "Legal Form")]
        public string LegalForm { get; set; }

        [Required]
        [Display(Name = "Legal Vehicle")]
        public string LegalVehicle { get; set; }

        [Required]
        [Display(Name = "Legal Type")]
        public string LegalType { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "Fund Admin Code")]
        public string FACode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "Dep. Code")]
        public string DEPCode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "Transfer Agent Code")]
        public string TACode { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        public string CompanyTypeDesc { get; set; }

        [Required]
        [Display(Name = "Company Type")]
        public string CompanyAcronym { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "TIN Number")]
        public string TinNumber { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "LEI Code")]
        public string LEICode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$")]
        [Display(Name = "Reg. Number")]
        public string RegNumber { get; set; }
    }
}
