// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Binding model for fund

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.InputModels.Funds
{
    using System.ComponentModel.DataAnnotations;

    public abstract class FundBindingModel : BaseEntityBindingModel
    {
        [Display(Name = "Fund Id Pharus")]
        public int FundId { get; set; }

        [Required(ErrorMessage = "You must enter a value for the Fund Name!")]
        [StringLength(200, ErrorMessage = "The Fund Name must be no longer than 200 characters")]
        [RegularExpression(@"^[A-Z-0-9]+(\s[A-Z-0-9]+)*$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Official Fund Name")]
        public string FundName { get; set; }

        [Required]
        [Display(Name = "Legal Form")]
        public string LegalForm { get; set; }

        [Required]
        [Display(Name = "Legal Vehicle")]
        public string LegalVehicle { get; set; }

        [Required]
        [Display(Name = "Legal Type")]
        public string LegalType { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Dep. Code")]
        public string DEPCode { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        public string CompanyTypeDesc { get; set; }

        [RegularExpression(@"^[0-9]+(\s[0-9]+)*$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "TIN Number")]
        public string TinNumber { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Not in correct format!")]
        [Display(Name = "Reg. Number")]
        public string RegNumber { get; set; }
    }
}