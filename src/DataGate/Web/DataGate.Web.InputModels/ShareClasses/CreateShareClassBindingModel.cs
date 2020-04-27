namespace DataGate.Web.InputModels.ShareClasses
{
    using System.ComponentModel.DataAnnotations;

    public class CreateShareClassInputModel : ShareClassInputModel
    {
        [Required(ErrorMessage = "Please choose a subfund container!")]
        [Display(Name = "Sub Fund Container")]
        public string SubFundContainer { get; set; }
    }
}
