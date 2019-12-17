// Model class for binding subfunds

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.SubFunds
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateSubFundBindingModel : BaseEntityBindingModel
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
        public string SfStatus { get; set; }

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
        public DateTime? FirstNavDate { get; set; }

        [Display(Name = "Last Nav Date")]
        public DateTime? LastNavDate { get; set; }

        [Display(Name = "CSSF Auth. Date")]
        public DateTime? CSSFAuthDate { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "LEI Code")]
        public string LEICode { get; set; }

        [Display(Name = "Cesr Class")]
        public string CesrClass { get; set; }

        [Display(Name = "Geographical Focus")]
        public string GeographicalFocus { get; set; }

        [Display(Name = "Global Exposure")]
        public string GlobalExposure { get; set; }

        [Display(Name = "Currency")]
        public string CurrencyCode { get; set; }

        [Display(Name = "NAV Frequency")]
        public string Frequency { get; set; }

        [Display(Name = "Valuation Date")]
        public string ValuationDate { get; set; }

        [Display(Name = "Calculation Date")]
        public string CalculationDate { get; set; }

        [Display(Name = "Derivatives")]
        public string Derivatives { get; set; }

        [Display(Name = "Deriv. Market")]
        public string DerivMarket { get; set; }

        [Display(Name = "Deriv. Purpose")]
        public string DerivPurpose { get; set; }

        [Display(Name = "Principal Asset Class")]
        public string PrincipalAssetClass { get; set; }

        [Display(Name = "Type Of Market")]
        public string TypeOfMarket { get; set; }

        [Display(Name = "Principal Investment Strategy")]
        public string PrincipalInvestmentStrategy { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Clearing Code")]
        public string ClearingCode { get; set; }

        [Display(Name = "Morning Star Category")]
        public string SfCatMorningStar { get; set; }

        [Display(Name = "Six Category")]
        public string SfCatSix { get; set; }

        [Display(Name = "Bloomberg Category")]
        public string SfCatBloomberg { get; set; }

        public List<string> ExistingSubFundNames { get; set; }
    }
}