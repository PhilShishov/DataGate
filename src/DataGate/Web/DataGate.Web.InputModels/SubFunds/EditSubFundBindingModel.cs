namespace DataGate.Web.InputModels.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public class EditSubFundInputModel : SubFundInputModel
    {
        [Required]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }
    }
}
