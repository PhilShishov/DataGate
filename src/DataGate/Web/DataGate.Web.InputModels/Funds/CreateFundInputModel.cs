namespace DataGate.Web.InputModels.Funds
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class CreateFundInputModel : BaseEntityInputModel
    {
        public CreateFundInputModel()
        {
            this.InitialDate = DateTime.Today;
        }

        [Display(Name = "Valid Until")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.FundRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.FundLength)]
        [RegularExpression(@"^[A-Z-0-9]+(\s[A-Z-0-9]+)*$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Official Fund Name")]
        public string FundName { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Legal Form")]
        public string LegalForm { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Legal Vehicle")]
        public string LegalVehicle { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Legal Type")]
        public string LegalType { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Dep. Code")]
        public string DEPCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Company Description")]
        public string CompanyTypeDesc { get; set; }

        [RegularExpression(@"^[0-9]+(\s[0-9]+)*$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "TIN Number")]
        public string TinNumber { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Reg. Number")]
        public string RegNumber { get; set; }
    }
}
