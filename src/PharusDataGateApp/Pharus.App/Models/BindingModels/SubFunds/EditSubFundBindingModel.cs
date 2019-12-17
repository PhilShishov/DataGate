// Model class for binding subfunds

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.SubFunds
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditSubFundBindingModel : BaseEntityBindingModel
    {
        [Required(ErrorMessage = "Initial Date cannot be null")]
        [Display(Name = "Initial Date")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "You must enter a value for the SubFund Name!")]
        [StringLength(200, ErrorMessage = "The SubFund Name must be no longer than 200 characters")]
        [RegularExpression(@"^[A-Z-0-9]+(\s[A-Z-0-9]+)*$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Official SubFund Name")]
        public string SubFundName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string FStatus { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "CSSF Code")]
        public string CSSFCode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Fund Admin Code")]
        [Required]
        public string FACode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Depository Bank Code")]
        public string DBCode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Transfer Agent Code")]
        public string TACode { get; set; }

        [Display(Name = "First Nav Date")]
        public DateTime FirstNavDate { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "LEI Code")]
        public string LEICode { get; set; }

        public SelectList CalculationDate { get; set; }

        public SelectList CesrClass { get; set; }

        public SelectList CurrencyCode { get; set; }

        public SelectList Derivatives { get; set; }

        public SelectList DerivMarket { get; set; }

        public SelectList DerivPurpose { get; set; }

        public SelectList Frequency { get; set; }

        public SelectList GeographicalFocus { get; set; }

        public SelectList GlobalExposure { get; set; }

        public SelectList PrincipalAssetClass { get; set; }

        public SelectList PrincipalInvestmentStrategy { get; set; }

        public SelectList SfCatBloomberg { get; set; }

        public SelectList SfCatMorningStar { get; set; }

        public SelectList SfCatSix { get; set; }

        public SelectList SfStatus { get; set; }

        public SelectList TypeOfMarket { get; set; }

        public SelectList ValuationDate { get; set; }

        public List<string> ExistingSubFundNames { get; set; }
    }
}
