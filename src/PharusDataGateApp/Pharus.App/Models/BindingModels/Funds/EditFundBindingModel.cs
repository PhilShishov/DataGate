namespace Pharus.App.Models.BindingModels.Funds
{
    using System.ComponentModel.DataAnnotations;

    public class EditFundBindingModel : FundBindingModel
    {
        [Required]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }
    }
}
