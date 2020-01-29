namespace Pharus.App.Models.BindingModels.ShareClasses
{
    using System.ComponentModel.DataAnnotations;

    public class CreateShareClassBindingModel : ShareClassBindingModel
    {
        [Required(ErrorMessage = "Please choose a subfund container!")]
        [Display(Name = "Sub Fund Container")]
        public string SubFundContainer { get; set; }
    }
}
