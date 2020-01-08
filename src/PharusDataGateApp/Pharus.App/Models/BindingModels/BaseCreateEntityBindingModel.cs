// Abstract model class for create bind entity
// for code reuse

// Created: 01/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseCreateEntityBindingModel
    {
        [Required(ErrorMessage = "Initial Date cannot be empty!")]
        [Display(Name = "Initial Date")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "CSSF Code")]
        public string CSSFCode { get; set; }

        [Required(ErrorMessage = "Fund Admin Code cannot be empty!")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Fund Admin Code")]
        public string FACode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Transfer Agent Code")]
        public string TACode { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "LEI Code")]
        public string LEICode { get; set; }

        public List<string> ExistingEntitiesNames { get; set; }
    }
}
