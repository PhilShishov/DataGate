namespace Pharus.App.Models.BindingModels.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public class EditSubFundBindingModel : SubFundBindingModel
    {
        [Required]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }
    }
}
