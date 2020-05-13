namespace DataGate.Web.InputModels.Funds
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateFundInputModel : FundInputModel
    {
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
    }
}
